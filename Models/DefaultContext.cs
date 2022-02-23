using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace TodoList.Models
{
    public class DefaultContext : DbContext
    {
        public DefaultContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Tache> Taches { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Projet> Projets { get; set; }
    }
}