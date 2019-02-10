using InfoTemTuiFly.Models;
using InfoTemTuiFly.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InfoTemTuiFly.Controllers
{
    /// <summary>
    /// Airports Controller
    /// </summary>
    public class AirportsController : Controller
    {
        private readonly IAirportService _airportService;

        public AirportsController(IAirportService airportService)
        {
            _airportService = airportService;
        }

        // GET: Airports
        public IActionResult Index()
        {
            return View(_airportService.GetAll()?.ConvertAll(a => new AirportViewModel(a)));
        }

        // GET: Airports/Details/5
        public IActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }

            var airport = _airportService.GetById(id.Value);
            if (airport == null)
            {
                return NotFound();
            }

            return View(new AirportViewModel(airport));
        }

        // GET: Airports/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Airports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,GpsCoords")] AirportViewModel airportvm)
        {
            if (ModelState.IsValid)
            {
                _airportService.Save(airportvm.Airport);
                return RedirectToAction(nameof(Index));
            }
            return View(airportvm);
        }

        // GET: Airports/Edit/5
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var airport = _airportService.GetById(id.Value);

            if (airport == null)
            {
                return NotFound();
            }
            return View(new AirportViewModel(airport));
        }

        // POST: Airports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,GpsCoords")] AirportViewModel airportvm)
        {
            if (id != airportvm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _airportService.Save(airportvm.Airport);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AirportExists(airportvm.Id))
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
            return View(airportvm);
        }

        // GET: Airports/Delete/5
        public IActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var airport = _airportService.GetById(id.Value);
            if (airport == null)
            {
                return NotFound();
            }

            return View(airport);
        }

        // POST: Airports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _airportService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Check if an airports exists
        /// </summary>
        /// <param name="id">The Airport Identifier</param>
        /// <returns>Result</returns>
        private bool AirportExists(int id)
        {
            return _airportService.GetById(id) != null;
        }
    }
}