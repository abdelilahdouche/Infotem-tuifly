using InfoTemTuiFly.Models;
using InfoTemTuiFly.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InfoTemTuiFly.Controllers
{
    /// <summary>
    /// Flight controller
    /// </summary>
    public class FlightsController : Controller
    {
        /// <summary>
        /// Gets the Flight Service
        /// </summary>
        private readonly IFlightService _flightService;

        /// <summary>
        /// Gets the Airport service
        /// </summary>
        private readonly IAirportService _airportService;

        /// <summary>
        /// Construtor init services
        /// </summary>
        /// <param name="flightService">Flight Service</param>
        /// <param name="airportService">Airport service</param>
        public FlightsController(IFlightService flightService, IAirportService airportService)
        {
            _flightService = flightService;
            _airportService = airportService;
        }

        // GET: Flights
        public IActionResult Index()
        {
            return View(_flightService?.GetAll()?.ConvertAll(a => new FlightViewModel(a)));
        }

        // GET: Flights/Details/5
        public IActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }

            var flight = _flightService.GetById(id.Value);
            if (flight == null)
            {
                return NotFound();
            }

            return View(new FlightViewModel(flight));
        }

        // GET: Flights/Create
        public IActionResult Create()
        {
            FlightViewModel vm = new FlightViewModel
            {
                AirportsList = _airportService.GetAll()
            };
            return View(vm);
        }

        // POST: Flights/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,DeparatureId,DestinationId")] FlightViewModel flightvm)
        {
            if (ModelState.IsValid)
            {
                _flightService.Save(flightvm.Flight);
                return RedirectToAction(nameof(Index));
            }
            flightvm.AirportsList = _airportService.GetAll();
            return View(flightvm);
        }

        // GET: Flights/Edit/5
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var flight = _flightService.GetById(id.Value);
            if (flight == null)
            {
                return NotFound();
            }
            var flightvm = new FlightViewModel
            {
                AirportsList = _airportService.GetAll()
            };
            return View(flightvm);
        }

        // POST: Flights/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,DeparatureId,DestinationId")] FlightViewModel flightvm)
        {
            if (id != flightvm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _flightService.Save(flightvm.Flight);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlightExists(flightvm.Id))
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
            flightvm.AirportsList = _airportService.GetAll();
            return View(flightvm);
        }

        // GET: Flights/Delete/5
        public IActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var flight = _flightService.GetById(id.Value);
            if (flight == null)
            {
                return NotFound();
            }

            return View(flight);
        }

        // POST: Flights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _flightService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Check if a flight exists
        /// </summary>
        /// <param name="id">The Flight Identifier</param>
        /// <returns>Result</returns>
        private bool FlightExists(int id)
        {
            return _flightService.GetById(id) != null;
        }
    }
}