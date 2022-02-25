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
    public class TacheController : Controller
    {
        private readonly ILogger<TacheController> _logger;
        private readonly DefaultContext _context = null;

        public TacheController(ILogger<TacheController> logger, DefaultContext context)
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
            SetCategoriesList();
            SetProjetsList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Tache tache)
        {
            IActionResult result = View(tache);
            if ( ModelState.IsValid )
            {
                _context.Taches.Add(tache);
                _context.SaveChanges();
                result = RedirectToAction("Index", "Home");
            }
            return result;
        }

        public IActionResult Edit(int id)
        {
            Tache tache = null;
            SetCategoriesList();
            SetProjetsList();
            tache = _context.Taches.First( tache => tache.Id == id );
            return View(tache);
        }

        [HttpPost]
        public IActionResult Edit(Tache tache)
        {
            _context.Taches.Update(tache);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        private void SetCategoriesList()
        {
            ViewBag.CategoriesList = _context.Categories.ToList();
        }

        private void SetProjetsList()
        {
            ViewBag.projetsList = _context.Badges.ToList();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}