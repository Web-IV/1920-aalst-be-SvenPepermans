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

                var sven = new Gebruiker { Voornaam = "Sven", Achternaam = "Pepermans", Gebruikersnaam = "SvenP", Email = "svenp@gmail.com" };
                var fleur = new Gebruiker { Voornaam = "Fleur", Achternaam = "Schietecat", Gebruikersnaam = "Bloempje", Email = "fleur@gmail.com" };
                await CreateUser(sven.Gebruikersnaam, sven.Email, "svenzijnwachtwoord");
                await CreateUser(fleur.Gebruikersnaam, fleur.Email, "fleurhaarwachtwoord");
                var gebruikers = new[] { sven, fleur };
                _dbContext.Gebruikers.AddRange(gebruikers);
                _dbContext.SaveChanges();



                //fotos
                var fotoFietsen = new Foto("fietsen.jpeg");
                var fotoFietsen2 = new Foto("demuur.jpeg");
                var fotoWinterPret = new Foto("sneeuw.jpeg");
                var fotos = new[] { fotoFietsen, fotoFietsen2, fotoWinterPret };
                _dbContext.Fotos.AddRange(fotos);
                _dbContext.SaveChanges();

                //categories
                var sport = new Categorie("Sport");
                var lente = new Categorie("Lente");
                var winter = new Categorie("Winter");
                var familie = new Categorie("Familie");
                var categories = new[] { sport, lente, winter, familie };
                _dbContext.Categories.AddRange(categories);
                _dbContext.SaveChanges();

                //posts
                var fietsen = new Post("De muur van Geraardsbergen overwonnen, op naar Mont Ventoux!", sport);
                fietsen.AddFoto(fotoFietsen);
                fietsen.AddFoto(fotoFietsen2);         
                var sneeuwpret = new Post("Wat een mooie winter is het geweest.", winter);
                sneeuwpret.AddFoto(fotoWinterPret);
                var posts = new[] { fietsen, sneeuwpret };
                _dbContext.Posts.AddRange(posts);
                _dbContext.SaveChanges();



            }
            }
            private async Task CreateUser(string username, string email, string password)
            {
                var user = new IdentityUser { UserName = username, Email = email };
                await _userManager.CreateAsync(user, password);
            }
        
    }
}
