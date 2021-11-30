using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VehiclesAccounting.Core.Interfaces;
using VehiclesAccounting.Core.ProjectAggregate;
using VehiclesAccounting.Core.Services;
using VehiclesAccounting.Infrastructure.Data;
using VehiclesAccounting.Web.ViewModels;
using VehiclesAccounting.Web.ViewModels.StolenCars;

namespace VehiclesAccounting.Web.Controllers
{
    [ResponseCache(CacheProfileName = "Caching")]
    [Authorize(Roles = "moder, admin")]
    public class StolenCarsController : Controller
    {
        private readonly ICarService _carService;
        private readonly ITrafficPoliceOfficerService _officerService;
        private readonly IStolenCarService _service;
        public StolenCarsController(IStolenCarService service, ICarService carService, ITrafficPoliceOfficerService officerService)
        {
            _service = service;
            _carService = carService;
            _officerService = officerService;
        }
        [HttpGet]
        public async Task<IActionResult> Index(SortState sortOrder, string carBrandName, string engineNumber, DateTime? theftStart, DateTime? theftEnd, string mark, int page = 1)
        {
            int pageSize = 20;
            IEnumerable<StolenCar> stolenCars = await _service.SortFilter(sortOrder, carBrandName, engineNumber, theftStart, theftEnd, mark);
            int count = stolenCars.ToList().Count;
            List<StolenCar> items = stolenCars.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            StolenCarViewModel viewModel = new()
            {
                PageViewModel = new PageViewModel(count, page, pageSize),
                SortViewModel = new SortViewModel(sortOrder),
                FilterViewModel = new FilterViewModel(carBrandName, engineNumber, theftStart, theftEnd, mark),
                StolenCars = items
            };
            return View(viewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var stolenCar = await _service.GetByIdAsync((int)id);
            if (stolenCar == null)
            {
                return NotFound();
            }
            var cars = await _carService.ReadAllAsync();
            var trafficPoliceOfficers = await _officerService.ReadAllAsync();
            ViewData["CarId"] = new SelectList(cars, "Id", "RegistrationNumber");
            IEnumerable<OfficerViewModel> officers = trafficPoliceOfficers.Select(x => new OfficerViewModel(x.Id, x.Name + " " + x.Surname + " " + x.Patronymic + " " + x.Birthday.Year));
            ViewData["InspectorId"] = new SelectList(officers, "Id", "NSPB");
            return View(stolenCar);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var cars = await _carService.ReadAllAsync();
            var trafficPoliceOfficers = await _officerService.ReadAllAsync();
            ViewData["CarId"] = new SelectList(cars, "Id", "RegistrationNumber");
            IEnumerable<OfficerViewModel> officers = trafficPoliceOfficers.Select(x => new OfficerViewModel(x.Id, x.Name + " " + x.Surname + " " + x.Patronymic + " " + x.Birthday.Year));
            ViewData["InspectorId"] = new SelectList(officers, "Id", "NSPB");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StatementDate,InsuranceType,Circumstances,MarkAboutFinding,TheftDate,InspectorId,CarId")] StolenCar stolenCar)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(stolenCar);
                return RedirectToAction(nameof(Index));
            }
            var cars = await _carService.ReadAllAsync();
            var trafficPoliceOfficers = await _officerService.ReadAllAsync();
            ViewData["CarId"] = new SelectList(cars, "Id", "RegistrationNumber", stolenCar.CarId);
            IEnumerable<OfficerViewModel> officers = trafficPoliceOfficers.Select(x => new OfficerViewModel(x.Id, x.Name + " " + x.Surname + " " + x.Patronymic + " " + x.Birthday.Year));
            ViewData["InspectorId"] = new SelectList(officers, "Id", "NSPB", stolenCar.InspectorId);
            return View(stolenCar);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var stolenCar = await _service.GetByIdAsync((int)id);
            if (stolenCar == null)
            {
                return NotFound();
            }
            var cars = await _carService.ReadAllAsync();
            var trafficPoliceOfficers = await _officerService.ReadAllAsync();
            ViewData["CarId"] = new SelectList(cars, "Id", "RegistrationNumber", stolenCar.CarId);
            IEnumerable<OfficerViewModel> officers = trafficPoliceOfficers.Select(x => new OfficerViewModel(x.Id, x.Name + " " + x.Surname + " " + x.Patronymic + " " + x.Birthday.Year));
            ViewData["InspectorId"] = new SelectList(officers, "Id", "NSPB", stolenCar.InspectorId);
            return View(stolenCar);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StatementDate,InsuranceType,Circumstances,MarkAboutFinding,TheftDate,InspectorId,CarId")] StolenCar stolenCar)
        {
            if (id != stolenCar.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    await _service.UpdateAsync(stolenCar);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StolenCarExists(stolenCar.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            var cars = await _carService.ReadAllAsync();
            var trafficPoliceOfficers = await _officerService.ReadAllAsync();
            ViewData["CarId"] = new SelectList(cars, "Id", "RegistrationNumber", stolenCar.CarId);
            IEnumerable<OfficerViewModel> officers = trafficPoliceOfficers.Select(x => new OfficerViewModel(x.Id, x.Name + " " + x.Surname + " " + x.Patronymic + " " + x.Birthday.Year));
            ViewData["InspectorId"] = new SelectList(officers, "Id", "NSPB", stolenCar.InspectorId);
            return View(stolenCar);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var stolenCar = await _service.GetByIdAsync((int)id);
            if (stolenCar == null)
            {
                return NotFound();
            }
            return View(stolenCar);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stolenCar = await _service.DeleteAsyncById(id);
            return RedirectToAction(nameof(Index));
        }

        private bool StolenCarExists(int id)
        {
            return _service.GetByIdAsync(id) is not null;
        }
    }
}
