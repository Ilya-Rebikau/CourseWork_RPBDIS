using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehiclesAccounting.Core.Interfaces;
using VehiclesAccounting.Core.ProjectAggregate;
using VehiclesAccounting.Core.Services;
using VehiclesAccounting.Web.ViewModels;
using VehiclesAccounting.Web.ViewModels.TrafficPoliceOfficers;

namespace VehiclesAccounting.Web.Controllers
{
    [ResponseCache(CacheProfileName = "Caching")]
    [Authorize(Roles = "admin")]
    public class TrafficPoliceOfficersController : Controller
    {
        private readonly ITrafficPoliceOfficerService _service;
        private readonly ICarService _carService;
        public TrafficPoliceOfficersController(ITrafficPoliceOfficerService service, ICarService carService)
        {
            _service = service;
            _carService = carService;
        }
        [HttpGet]
        public async Task<IActionResult> Index(SortState sortOrder, int page = 1)
        {
            int pageSize = 20;
            IEnumerable<TrafficPoliceOfficer> trafficPoliceOfficers = await _service.Sort(sortOrder);
            int count = trafficPoliceOfficers.ToList().Count;
            List<TrafficPoliceOfficer> items = trafficPoliceOfficers.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            TrafficPoliceOfficerViewModel viewModel = new()
            {
                PageViewModel = new PageViewModel(count, page, pageSize),
                SortViewModel = new SortViewModel(sortOrder),
                TrafficPoliceOfficers = items
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
            TrafficPoliceOfficer trafficPoliceOfficer = await _service.GetByIdAsync((int)id);
            if (trafficPoliceOfficer == null)
            {
                return NotFound();
            }
            return View(trafficPoliceOfficer);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Surname,Patronymic,Birthday,Post")] TrafficPoliceOfficer trafficPoliceOfficer)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(trafficPoliceOfficer);
                return RedirectToAction(nameof(Index));
            }
            return View(trafficPoliceOfficer);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            TrafficPoliceOfficer trafficPoliceOfficer = await _service.UpdateByIdAsync((int)id);
            if (trafficPoliceOfficer == null)
            {
                return NotFound();
            }
            return View(trafficPoliceOfficer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Surname,Patronymic,Birthday,Post")] TrafficPoliceOfficer trafficPoliceOfficer)
        {
            if (id != trafficPoliceOfficer.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    await _service.UpdateAsync(trafficPoliceOfficer);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrafficPoliceOfficerExists(trafficPoliceOfficer.Id))
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
            return View(trafficPoliceOfficer);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            TrafficPoliceOfficer trafficPoliceOfficer = await _service.GetByIdAsync((int)id);
            if (trafficPoliceOfficer == null)
            {
                return NotFound();
            }
            return View(trafficPoliceOfficer);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cars = await _carService.ReadAllAsync();
            cars = cars.Where(car => car.CarBrandId == id);
            if (cars.Count() == 0)
                await _service.DeleteAsyncById(id);
            else
                return Conflict();
            return RedirectToAction(nameof(Index));
        }
        private bool TrafficPoliceOfficerExists(int id)
        {
            return _service.GetByIdAsync(id) is not null;
        }
    }
}
