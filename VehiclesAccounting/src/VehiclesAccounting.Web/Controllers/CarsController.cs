using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VehiclesAccounting.Core.ProjectAggregate;
using VehiclesAccounting.Infrastructure.Data;
using VehiclesAccounting.Web;

namespace VehiclesAccounting.Web.Controllers
{
    public class CarsController : Controller
    {
        private readonly VehiclesContext _context;

        public CarsController(VehiclesContext context)
        {
            _context = context;
        }

        // GET: Cars
        public async Task<IActionResult> Index()
        {
            var vehiclesContext = _context.Cars.Include(c => c.CarBrand).Include(c => c.Owner).Include(c => c.TrafficPoliceOfficer);
            return View(await vehiclesContext.ToListAsync());
        }

        // GET: Cars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .Include(c => c.CarBrand)
                .Include(c => c.Owner)
                .Include(c => c.TrafficPoliceOfficer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: Cars/Create
        public IActionResult Create()
        {
            ViewData["CarBrandId"] = new SelectList(_context.CarBrands, "Id", "Id");
            ViewData["OwnerId"] = new SelectList(_context.Owners, "Id", "Id");
            ViewData["TrafficPoliceOfficerId"] = new SelectList(_context.TrafficPoliceOfficers, "Id", "Id");
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RegistrationNumber,Photo,BodyNumber,EngineNumber,TechPassportNumber,DateCreating,DateRegistration,DateInspection,Color,Description,OwnerId,TrafficPoliceOfficerId,CarBrandId")] Car car)
        {
            if (ModelState.IsValid)
            {
                _context.Add(car);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarBrandId"] = new SelectList(_context.CarBrands, "Id", "Id", car.CarBrandId);
            ViewData["OwnerId"] = new SelectList(_context.Owners, "Id", "Id", car.OwnerId);
            ViewData["TrafficPoliceOfficerId"] = new SelectList(_context.TrafficPoliceOfficers, "Id", "Id", car.TrafficPoliceOfficerId);
            return View(car);
        }

        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            ViewData["CarBrandId"] = new SelectList(_context.CarBrands, "Id", "Id", car.CarBrandId);
            ViewData["OwnerId"] = new SelectList(_context.Owners, "Id", "Id", car.OwnerId);
            ViewData["TrafficPoliceOfficerId"] = new SelectList(_context.TrafficPoliceOfficers, "Id", "Id", car.TrafficPoliceOfficerId);
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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
                    _context.Update(car);
                    await _context.SaveChangesAsync();
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
            ViewData["CarBrandId"] = new SelectList(_context.CarBrands, "Id", "Id", car.CarBrandId);
            ViewData["OwnerId"] = new SelectList(_context.Owners, "Id", "Id", car.OwnerId);
            ViewData["TrafficPoliceOfficerId"] = new SelectList(_context.TrafficPoliceOfficers, "Id", "Id", car.TrafficPoliceOfficerId);
            return View(car);
        }

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .Include(c => c.CarBrand)
                .Include(c => c.Owner)
                .Include(c => c.TrafficPoliceOfficer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarExists(int id)
        {
            return _context.Cars.Any(e => e.Id == id);
        }
    }
}
