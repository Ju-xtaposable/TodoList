using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TodoList.Models;

namespace TodoList.Controllers
{
    // [Produces("application/json")]
    // [Route("api/Events")]
    public class EventController : Controller
    {
        private readonly ILogger<EventController> _logger;
        private readonly DefaultContext _context = null;

        public EventController(ILogger<EventController> logger, DefaultContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvents([FromQuery] DateTime start, [FromQuery] DateTime end)
        {
            return await _context.Events
                .Where(e => !((e.Start <= start) || (e.End >= end)))
                .ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> PostEvent([FromBody] Event @event)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Events.Add(@event);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEvent", new { id = @event.Id }, @event);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @event = await _context.Events.SingleOrDefaultAsync(m => m.Id == id);
            if (@event == null)
            {
                return NotFound();
            }

            _context.Events.Remove(@event);
            await _context.SaveChangesAsync();

            return Ok(@event);
        }

        public IActionResult Create(Event e)
        {
            SetBadgessList();
            return View(e);
        }

        [HttpPost]
        public IActionResult Create(Event ev, int[] badges)
        {
            IActionResult result = View(ev);

            foreach (int badgeId in badges)
            {
                Badge badge = _context.Badges.First( badge => badge.Id == badgeId);
                ev.Badges.Add(badge);
            }

            if ( ModelState.IsValid )
            {
                _context.Events.Add(ev);
                _context.SaveChanges();
                result = RedirectToAction("Index", "Home");
            }
            return result;
        }

        public IActionResult FromTache(int id)
        {
            Tache tache = null;
            tache = _context.Taches.Include( tache => tache.Badges).First( tache => tache.Id == id);
            Event e = new Event() { Text=tache.Name, Description=tache.Description, Badges=tache.Badges};
            return RedirectToAction("Create", e);
        }

        public IActionResult FromNote(int id)
        {
            Note note = null;
            note = _context.Notes.Include( note => note.Badges).First( note => note.Id == id);
            Event e = new Event() { Text=note.Titre, Description=note.Description, Badges=note.Badges};
            return RedirectToAction("Create", e);
        }

        private void SetBadgessList()
        {
            ViewBag.badgesList = _context.Badges.OrderBy(badge => badge.Numero).ToList();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}