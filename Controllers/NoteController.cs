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
    public class NoteController : Controller
    {
        private readonly ILogger<NoteController> _logger;
        private readonly DefaultContext _context = null;

        public NoteController(ILogger<NoteController> logger, DefaultContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            List<Note> notes = _context.Notes.Include( note => note.Badges ).ToList();
            return View(notes);
        }

        public IActionResult Create()
        {
            SetCategoriesList();
            SetBadgessList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Note note, int[] badges)
        {
            IActionResult result = View(note);

            foreach (int badgeId in badges)
            {
                Badge badge = _context.Badges.First( badge => badge.Id == badgeId);
                note.Badges.Add(badge);
            }

            if ( ModelState.IsValid )
            {
                _context.Notes.Add(note);
                _context.SaveChanges();
                result = RedirectToAction("Index");
            }
            return result;
        }

        public IActionResult Edit(int id)
        {
            SetCategoriesList();
            SetBadgessList();
            Note note = _context.Notes.Include( note => note.Badges ).First( note => note.Id == id );
            return View(note);
        }

        [HttpPost]
        public IActionResult Edit(Note note, int[] badges)
        {
            Note noteToUpdate = _context.Notes.Include( note => note.Badges ).First( note => note.Id == note.Id);
            noteToUpdate.Badges.Clear();

            foreach (int badgeId in badges)
            {
                Badge badge = _context.Badges.First( badge => badge.Id == badgeId);
                noteToUpdate.Badges.Add(badge);
            }

            _context.Notes.Update(noteToUpdate);
            _context.SaveChanges();
            return RedirectToAction("Index", "Note");
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