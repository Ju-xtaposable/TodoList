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

            modelBuilder.Entity<Event>()
                .HasMany(p => p.Badges)
                .WithMany(p => p.Events)
                .UsingEntity(j => j.ToTable("EventBadge"));

            modelBuilder.Entity<Note>()
                .HasMany(p => p.Badges)
                .WithMany(p => p.Notes)
                .UsingEntity(j => j.ToTable("NoteBadge"));
        }

        public DbSet<Tache> Taches { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Badge> Badges { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Note> Notes { get; set; }
    }
}