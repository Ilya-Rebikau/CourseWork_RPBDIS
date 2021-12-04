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
using VehiclesAccounting.Web.ViewModels.Owners;

namespace VehiclesAccounting.Web.Controllers
{
    [ResponseCache(CacheProfileName = "Caching")]
    [Authorize(Roles = "moder, admin")]
    public class OwnersController : Controller
    {
        private readonly IOwnerService _service;
        private readonly ICarService _carService;
        public OwnersController(IOwnerService service, ICarService carService)
        {
            _carService = carService;
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string categories, SortState sortOrder, string didLicenseFinish, int page = 1)
        {
            int pageSize = 20;
            IEnumerable<Owner> owners = await _service.SortFilter(sortOrder, categories, didLicenseFinish);
            int count = owners.ToList().Count;
            List<Owner> items = owners.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            OwnerViewModel viewModel = new()
            {
                PageViewModel = new PageViewModel(count, page, pageSize),
                SortViewModel = new SortViewModel(sortOrder),
                FilterViewModel = new FilterViewModel(categories, didLicenseFinish),
                Owners = items
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
            Owner owner = await _service.GetByIdAsync((int)id);
            if (owner == null)
            {
                return NotFound();
            }
            return View(owner);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Surname,Patronymic,Birthday,PassportInfo,LicenseNumber,LicenseStart,LicenseEnd,Categories,ExtraInformation")] Owner owner)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(owner);
                return RedirectToAction(nameof(Index));
            }
            return View(owner);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Owner owner = await _service.GetByIdAsync((int)id);
            if (owner == null)
            {
                return NotFound();
            }
            return View(owner);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Surname,Patronymic,Birthday,PassportInfo,LicenseNumber,LicenseStart,LicenseEnd,Categories,ExtraInformation")] Owner owner)
        {
            if (id != owner.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    await _service.UpdateAsync(owner);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OwnerExists(owner.Id))
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
            return View(owner);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Owner owner = await _service.GetByIdAsync((int)id);
            if (owner == null)
            {
                return NotFound();
            }
            return View(owner);
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
        private bool OwnerExists(int id)
        {
            return _service.GetByIdAsync(id) is not null;
        }
    }
}
