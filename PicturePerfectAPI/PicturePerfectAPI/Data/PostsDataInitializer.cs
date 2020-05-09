using Microsoft.AspNetCore.Identity;
using PicturePerfectAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PicturePerfectAPI.Data
{
    public class PostsDataInitializer
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public PostsDataInitializer(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task  InitializeDataAsync()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {


                //Gebruikers

                var sven = new Gebruiker { Voornaam = "Sven", Achternaam = "Pepermans", Gebruikersnaam = "SvenP", Email = "svenp@gmail.com"};
                _dbContext.Gebruikers.Add(sven);
                await CreateUser(sven.Gebruikersnaam, sven.Email, "Sv3n123!");
                var fleur = new Gebruiker { Voornaam = "Fleur", Achternaam = "Schietecat", Gebruikersnaam = "Bloempje", Email = "fleur@gmail.com" };
                _dbContext.Gebruikers.Add(fleur);
                await CreateUser(fleur.Gebruikersnaam, fleur.Email, "Fl3ur123!");             
                _dbContext.SaveChanges();

                //categories
                var sport = new Categorie() { CategorieNaam = "Sport" };
                _dbContext.Categories.Add(sport);
                var lente = new  Categorie() { CategorieNaam = "Lente" };
                _dbContext.Categories.Add(lente);
                _dbContext.SaveChanges();
              
                //posts
                var fietstocht = new Post() { Beschrijving = "Een fietstocht", DatePosted = DateTime.Now, Likes = 10, Categorie = sport, GebruikerId = 1, Fotos = new List<Foto>() };
                _dbContext.Posts.Add(fietstocht);
                  var wandeling = new Post() { Beschrijving = "een lentewandelin", DatePosted = new DateTime(2010, 05, 13), Likes = 200, Categorie = lente, GebruikerId = 1, Fotos = new List<Foto>() };
                _dbContext.Posts.Add(wandeling);
                _dbContext.SaveChanges();

                //fotos
                Foto fietsfoto = new Foto("fiets.jpg");
                _dbContext.Fotos.Add(fietsfoto);
                fietstocht.Fotos.Add(fietsfoto);
                Foto boomfoto = new Foto("lenteboom.jpg");
                _dbContext.Fotos.Add(boomfoto);
                wandeling.Fotos.Add(boomfoto);
                _dbContext.SaveChanges();






            }
            }
            private async Task CreateUser(string gebruikersnaam, string email, string password)
            {
                var user = new IdentityUser { UserName = gebruikersnaam, Email = email };
                await _userManager.CreateAsync(user, password);
            }
        
    }
}
