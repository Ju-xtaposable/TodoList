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
    //[Route("[controller]")]
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