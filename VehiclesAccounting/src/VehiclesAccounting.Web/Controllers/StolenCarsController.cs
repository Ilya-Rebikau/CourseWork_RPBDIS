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
    public class StolenCarsController : Controller
    {
        private readonly VehiclesContext _context;

        public StolenCarsController(VehiclesContext context)
        {
            _context = context;
        }

        // GET: StolenCars
        public async Task<IActionResult> Index()
        {
            var vehiclesContext = _context.StolenCars.Include(s => s.Car).Include(s => s.Inspector);
            return View(await vehiclesContext.ToListAsync());
        }

        // GET: StolenCars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stolenCar = await _context.StolenCars
                .Include(s => s.Car)
                .Include(s => s.Inspector)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stolenCar == null)
            {
                return NotFound();
            }

            return View(stolenCar);
        }

        // GET: StolenCars/Create
        public IActionResult Create()
        {
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Id");
            ViewData["InspectorId"] = new SelectList(_context.TrafficPoliceOfficers, "Id", "Id");
            return View();
        }

        // POST: StolenCars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StatementDate,InsuranceType,Circumstances,MarkAboutFinding,TheftDate,InspectorId,CarId")] StolenCar stolenCar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stolenCar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Id", stolenCar.CarId);
            ViewData["InspectorId"] = new SelectList(_context.TrafficPoliceOfficers, "Id", "Id", stolenCar.InspectorId);
            return View(stolenCar);
        }

        // GET: StolenCars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stolenCar = await _context.StolenCars.FindAsync(id);
            if (stolenCar == null)
            {
                return NotFound();
            }
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Id", stolenCar.CarId);
            ViewData["InspectorId"] = new SelectList(_context.TrafficPoliceOfficers, "Id", "Id", stolenCar.InspectorId);
            return View(stolenCar);
        }

        // POST: StolenCars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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
                    _context.Update(stolenCar);
                    await _context.SaveChangesAsync();
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
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Id", stolenCar.CarId);
            ViewData["InspectorId"] = new SelectList(_context.TrafficPoliceOfficers, "Id", "Id", stolenCar.InspectorId);
            return View(stolenCar);
        }

        // GET: StolenCars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stolenCar = await _context.StolenCars
                .Include(s => s.Car)
                .Include(s => s.Inspector)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stolenCar == null)
            {
                return NotFound();
            }

            return View(stolenCar);
        }

        // POST: StolenCars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stolenCar = await _context.StolenCars.FindAsync(id);
            _context.StolenCars.Remove(stolenCar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StolenCarExists(int id)
        {
            return _context.StolenCars.Any(e => e.Id == id);
        }
    }
}
