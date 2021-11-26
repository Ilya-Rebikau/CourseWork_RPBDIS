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
using VehiclesAccounting.Web.ViewModels;
using VehiclesAccounting.Web.ViewModels.Cars;

namespace VehiclesAccounting.Web.Controllers
{
    [ResponseCache(CacheProfileName = "Caching")]
    [Authorize(Roles = "moder, admin")]
    public class CarsController : Controller
    {
        private readonly ICarService _service;
        private readonly ITrafficPoliceOfficerService _officerService;
        private readonly IOwnerService _ownerService;
        private readonly ICarBrandService _brandService;
        public CarsController(ICarService service, ITrafficPoliceOfficerService officerService, IOwnerService ownerService, ICarBrandService brandService)
        {
            _officerService = officerService;
            _ownerService = ownerService;
            _brandService = brandService;
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Index(SortState sortOrder, string carBrandName, int page = 1)
        {
            int pageSize = 20;
            IEnumerable<Car> cars = await _service.SortFilter(sortOrder, carBrandName);
            int count = cars.ToList().Count;
            List<Car> items = cars.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            CarViewModel viewModel = new()
            {
                PageViewModel = new PageViewModel(count, page, pageSize),
                SortViewModel = new SortViewModel(sortOrder),
                FilterViewModel = new FilterViewModel(carBrandName),
                Cars = items
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
            var car = await _service.GetByIdAsync((int)id);
            if (car == null)
            {
                return NotFound();
            }
            var owners = await _ownerService.ReadAllAsync();
            var trafficPoliceOfficers = await _officerService.ReadAllAsync();
            var carBrands = await _brandService.ReadAllAsync();
            ViewData["TrafficPoliceOfficerId"] = new SelectList(trafficPoliceOfficers.AsEnumerable(), "Id", "Surname");
            ViewData["CarBrandId"] = new SelectList(carBrands.AsEnumerable(), "Id", "Name");
            ViewData["OwnerId"] = new SelectList(owners.AsEnumerable(), "Id", "Surname");
            return View(car);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var owners = await _ownerService.ReadAllAsync();
            var trafficPoliceOfficers = await _officerService.ReadAllAsync();
            var carBrands = await _brandService.ReadAllAsync();
            ViewData["TrafficPoliceOfficerId"] = new SelectList(trafficPoliceOfficers.AsEnumerable(), "Id", "Id");
            ViewData["CarBrandId"] = new SelectList(carBrands.AsEnumerable(), "Id", "Name");
            ViewData["OwnerId"] = new SelectList(owners.AsEnumerable(), "Id", "PassportInfo");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RegistrationNumber,Photo,BodyNumber,EngineNumber,TechPassportNumber,DateCreating,DateRegistration,DateInspection,Color,Description,OwnerId,TrafficPoliceOfficerId,CarBrandId")] Car car)
        {

            if (ModelState.IsValid)
            {
                await _service.AddAsync(car);
                return RedirectToAction(nameof(Index));
            }
            var cars = await _service.ReadAllAsync();
            var owners = await _ownerService.ReadAllAsync();
            var trafficPoliceOfficers = await _officerService.ReadAllAsync();
            var carBrands = await _brandService.ReadAllAsync();
            ViewData["TrafficPoliceOfficerId"] = new SelectList(trafficPoliceOfficers.AsEnumerable(), "Id", "Id", car.TrafficPoliceOfficerId);
            ViewData["CarBrandId"] = new SelectList(carBrands.AsEnumerable(), "Id", "Name", car.CarBrandId);
            ViewData["OwnerId"] = new SelectList(owners.AsEnumerable(), "Id", "PassportInfo", car.OwnerId);
            return View(car);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var car = await _service.GetByIdAsync((int)id);
            if (car == null)
            {
                return NotFound();
            }
            var owners = await _ownerService.ReadAllAsync();
            var trafficPoliceOfficers = await _officerService.ReadAllAsync();
            var carBrands = await _brandService.ReadAllAsync();
            ViewData["TrafficPoliceOfficerId"] = new SelectList(trafficPoliceOfficers.AsEnumerable(), "Id", "Id", car.TrafficPoliceOfficerId);
            ViewData["CarBrandId"] = new SelectList(carBrands.AsEnumerable(), "Id", "Name", car.CarBrandId);
            ViewData["OwnerId"] = new SelectList(owners.AsEnumerable(), "Id", "PassportInfo", car.OwnerId);
            return View(car);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RegistrationNumber,Photo,BodyNumber,EngineNumber,TechPassportNumber,DateCreating,DateRegistration,DateInspection,Color,Description,OwnerId,TrafficPoliceOfficerId,CarBrandId")] Car car)
        {
            if (id != car.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    await _service.UpdateAsync(car);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.Id))
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
            var cars = await _service.ReadAllAsync();
            var owners = await _ownerService.ReadAllAsync();
            var trafficPoliceOfficers = await _officerService.ReadAllAsync();
            var carBrands = await _brandService.ReadAllAsync();
            ViewData["TrafficPoliceOfficerId"] = new SelectList(trafficPoliceOfficers.AsEnumerable(), "Id", "Id", car.TrafficPoliceOfficerId);
            ViewData["CarBrandId"] = new SelectList(carBrands.AsEnumerable(), "Id", "Name", car.CarBrandId);
            ViewData["OwnerId"] = new SelectList(owners.AsEnumerable(), "Id", "PassportInfo", car.OwnerId);
            return View(car);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var car = await _service.GetByIdAsync((int)id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var car = await _service.DeleteAsyncById(id);
            return RedirectToAction(nameof(Index));
        }
        private bool CarExists(int id)
        {
            return _service.GetByIdAsync(id) is not null;
        }
    }
}
