using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoList.Models;

namespace TodoList.DataLayers
{
    public class CategorieDataLayer
    {
        private readonly DefaultContext _context = null;

        public CategorieDataLayer(DefaultContext context)
        {
            _context = context;
        }

        public List<Categorie> GetCategories()
        {
            return _context.Categories
            .Include( categorie => categorie.Taches)
            .ThenInclude( tache => tache.Badges)
            .ToList();
        }
    }
}