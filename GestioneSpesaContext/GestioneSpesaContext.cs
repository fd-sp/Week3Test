using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Week3Test.RepoEntitiesEF.Entities;

namespace GestioneSpesaContext
{
    public class GestioneSpesaContext : DbContext
    {
        public GestioneSpesaContext() : base() { }
        public GestioneSpesaContext(DbContextOptions<GestioneSpesaContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(@"Persist Security Info= False; 
                                        Integrated Security = true; 
                                        Initial Catalog = GestioneSpesaContext; 
                                        Server = FRANK");
        }

        public DbSet<Spesa> Spese { get; set; }
        public DbSet<Categoria> Categoria { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Spesa>().HasOne(c => c.Categoria).WithMany(s => s.Spese);
        }
    }
}
