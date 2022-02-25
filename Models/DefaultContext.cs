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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tache>()
                .HasMany(p => p.Badges)
                .WithMany(p => p.Taches)
                .UsingEntity(j => j.ToTable("TacheBadge"));
        }

        public DbSet<Tache> Taches { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Badge> Badges { get; set; }
    }
}