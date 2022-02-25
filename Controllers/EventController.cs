using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Create()
        {
            SetBadgessList();
            return View();
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