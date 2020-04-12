using Microsoft.EntityFrameworkCore;
using PicturePerfectAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PicturePerfectAPI.Data
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Gebruiker> Gebruikers { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Foto> Fotos { get; set; }
        public DbSet<Categorie> Categories { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public ApplicationDbContext() { }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            
            builder.Entity<Post>().Property(p => p.Beschrijving).HasMaxLength(200).IsRequired();
            builder.Entity<Post>().Property(p => p.DatePosted).IsRequired();
            builder.Entity<Post>().HasOne(p => p.Categorie).WithMany().IsRequired();

            builder.Entity<Gebruiker>().HasKey(g => g.GebruikersId);
            builder.Entity<Gebruiker>().Property(g => g.Gebruikersnaam).HasMaxLength(50).IsRequired();
            builder.Entity<Gebruiker>().Property(g => g.Voornaam).HasMaxLength(10).IsRequired();
            builder.Entity<Gebruiker>().Property(g => g.Achternaam).HasMaxLength(20).IsRequired();
            builder.Entity<Gebruiker>().Property(g => g.Email).IsRequired().HasMaxLength(100);
           
            

            builder.Entity<Foto>().Property(f => f.Naam).IsRequired().HasMaxLength(50);

            builder.Entity<Categorie>().Property(c => c.CategorieNaam).IsRequired().HasMaxLength(25);

           
            
            



        }

    }
}
