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
using VehiclesAccounting.Web;
using VehiclesAccounting.Web.ViewModels;
using VehiclesAccounting.Web.ViewModels.CarBrands;

namespace VehiclesAccounting.Web.Controllers
{
    [ResponseCache(CacheProfileName = "Caching")]
    [Authorize(Roles = "admin, moder")]
    public class CarBrandsController : Controller
    {
        private readonly ICarBrandService _service;
        public CarBrandsController(ICarBrandService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Index(SortState sortOrder, int page = 1)
        {
            int pageSize = 20;
            IEnumerable<CarBrand> carBrands = await _service.Sort(sortOrder);
            int count = carBrands.ToList().Count;
            List<CarBrand> items = carBrands.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            CarBrandViewModel viewModel = new()
            {
                PageViewModel = new PageViewModel(count, page, pageSize),
                SortViewModel = new SortViewModel(sortOrder),
                CarBrands = items
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
            CarBrand carBrand = await _service.GetByIdAsync((int)id);
            if (carBrand == null)
            {
                return NotFound();
            }
            return View(carBrand);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Producer,Country,DateStart,DateFinish,Characteristics,Category,Description")] CarBrand carBrand)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(carBrand);
                return RedirectToAction(nameof(Index));
            }
            return View(carBrand);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var carBrand = await _service.UpdateByIdAsync((int)id);
            if (carBrand == null)
            {
                return NotFound();
            }
            return View(carBrand);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Producer,Country,DateStart,DateFinish,Characteristics,Category,Description")] CarBrand carBrand)
        {
            if (id != carBrand.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.UpdateAsync(carBrand);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarBrandExists(carBrand.Id))
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
            return View(carBrand);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            CarBrand carBrand = await _service.GetByIdAsync((int)id);
            if (carBrand == null)
            {
                return NotFound();
            }
            return View(carBrand);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsyncById(id);
            return RedirectToAction(nameof(Index));
        }
        private bool CarBrandExists(int id)
        {
            return _service.GetByIdAsync(id) is not null;
        }
    }
}
