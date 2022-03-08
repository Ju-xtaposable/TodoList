using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TodoList.DataLayers;
using TodoList.Models;

namespace TodoList.Controllers
{
    //[Route("[controller]")]
    public class TacheController : Controller
    {
        private readonly ILogger<TacheController> _logger;
        private readonly DefaultContext _context = null;
        private readonly CategorieDataLayer _categorieDataLayer = null;

        public TacheController(ILogger<TacheController> logger, DefaultContext context, CategorieDataLayer categorieDataLayer)
        {
            _logger = logger;
            _context = context;
            _categorieDataLayer = categorieDataLayer;
        }

        public IActionResult Index()
        {
            List<Categorie> categories = _categorieDataLayer.GetCategories();
            return View(categories);
        }

        public IActionResult Create()
        {
            SetCategoriesList();
            SetBadgessList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Tache tache, int[] badges) 
        {
            IActionResult result = View(tache);

            foreach (int badgeId in badges)
            {
                Badge badge = _context.Badges.First( badge => badge.Id == badgeId);
                tache.Badges.Add(badge);
            }

            if ( ModelState.IsValid )
            {
                _context.Taches.Add(tache);
                _context.SaveChanges();
                result = RedirectToAction("Index");
            }
            return result;
        }

        public IActionResult Edit(int id)
        {
            Tache tache = null;
            SetCategoriesList();
            SetBadgessList();
            tache = _context.Taches.Include( tache => tache.Badges ).First( tache => tache.Id == id );
            return View(tache);
        }

        [HttpPost]
        public IActionResult Edit(Tache tache, int[] badges)
        {
            Tache tacheToUpdate = _context.Taches.Include( tache => tache.Badges ).Include( tache => tache.Categorie ).First( t => t.Id == tache.Id);
            tacheToUpdate.Badges.Clear();

            foreach (int badgeId in badges)
            {
                Badge badge = _context.Badges.First( badge => badge.Id == badgeId);
                tacheToUpdate.Badges.Add(badge);
            }

            tacheToUpdate.CategorieId = tache.CategorieId;

            _context.Taches.Update(tacheToUpdate);
            _context.SaveChanges();
            return RedirectToAction("Index", "Tache");
        }

        // public JsonResult GetBadges(int TacheId, int index)
        // {
        //     Tache tache = _context.Taches.Include( tache => tache.Badges ).First( tache => tache.Id == TacheId );
        //     Badge badge = tache.Badges[index];
        //     return Json(badge.Name); 
        // }

        public IActionResult Delete(int id)
        {
            Tache tache = _context.Taches.First( tache => tache.Id == id);
            return View(tache);
        }

        [HttpPost]
        public IActionResult Delete(Tache tache)
        {
            _context.Taches.Remove(tache);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        private void SetCategoriesList()
        {
            ViewBag.CategoriesList = _context.Categories.ToList();
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