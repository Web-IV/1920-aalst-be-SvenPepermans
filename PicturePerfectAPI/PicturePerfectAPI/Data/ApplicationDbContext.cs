using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PicturePerfectAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PicturePerfectAPI.Data
{
    public class ApplicationDbContext: IdentityDbContext
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

            builder.Entity<Post>().HasKey(p => p.PostId);
            builder.Entity<Post>().Property(p => p.Beschrijving).HasMaxLength(200).IsRequired();
            builder.Entity<Post>().Property(p => p.DatePosted).IsRequired();
          //  builder.Entity<Post>().HasOne(p => p.Categorie).WithMany().IsRequired();
            builder.Entity<Post>().HasMany(p => p.Fotos).WithOne();
         //   builder.Entity<Post>().HasOne(p => p.Gebruiker).WithMany(g => g.Posts).HasForeignKey(p => p.GebruikerId).IsRequired();


            builder.Entity<Gebruiker>().HasKey(g => g.GebruikersId);
            builder.Entity<Gebruiker>().Property(g => g.Gebruikersnaam).HasMaxLength(50).IsRequired();
            builder.Entity<Gebruiker>().Property(g => g.Voornaam).HasMaxLength(10).IsRequired();
            builder.Entity<Gebruiker>().Property(g => g.Achternaam).HasMaxLength(20).IsRequired();
            builder.Entity<Gebruiker>().Property(g => g.Email).IsRequired().HasMaxLength(100);
            builder.Entity<Gebruiker>().HasMany(g => g.Fotos).WithOne();
            builder.Entity<Gebruiker>().HasMany(g => g.Posts).WithOne(p => p.Gebruiker);
            


            builder.Entity<Foto>().HasKey(f => f.FotoId);
            builder.Entity<Foto>().Property(f => f.Naam).IsRequired().HasMaxLength(50);
            builder.Entity<Foto>().Property(f => f.Url).IsRequired();       

            builder.Entity<Categorie>().Property(c => c.CategorieNaam).IsRequired().HasMaxLength(25);

           
            
            



        }

    }
}
