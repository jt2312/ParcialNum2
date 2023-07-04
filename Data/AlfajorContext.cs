using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Parcial2.Models;

namespace Parcial2.Data
{
    public class AlfajorContext : DbContext
    {
        public AlfajorContext (DbContextOptions<AlfajorContext> options)
            : base(options)
        {
        }

        public DbSet<Parcial2.Models.Alfajor> Alfajor { get; set; } = default!;

        public DbSet<Parcial2.Models.Marca> Marca { get; set; } = default!;
         protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Marca>()
            .HasMany(p => p.Alfajors)
            .WithMany(p => p.Marcas)
            .UsingEntity("MarcaAlfajores");

            base.OnModelCreating(modelBuilder);

        }
    }
}

