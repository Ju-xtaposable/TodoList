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
    // [Route("[controller]")]
    public class CategorieController : Controller
    {
        private readonly ILogger<CategorieController> _logger;
        private readonly DefaultContext _context = null;

        public CategorieController(ILogger<CategorieController> logger, DefaultContext context)
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
            return View();
        }

        [HttpPost]
        public IActionResult Create(Categorie categorie)
        {
            if ( ModelState.IsValid )
            {
                _context.Categories.Add(categorie);
                _context.SaveChanges();
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}