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

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


        }

    }
}
