using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplicationCoolerGaming.Data
{
    public class WebApplicationCoolerGamingContext : DbContext
    {
        public WebApplicationCoolerGamingContext (DbContextOptions<WebApplicationCoolerGamingContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplication1.Models.Games> Games { get; set; } = default!;

        public DbSet<WebApplication1.Models.Comments> Comments { get; set; }

        public DbSet<WebApplication1.Models.GamesGenres> GamesGenres { get; set; }

        public DbSet<WebApplication1.Models.Genres> Genres { get; set; }
    }
}
