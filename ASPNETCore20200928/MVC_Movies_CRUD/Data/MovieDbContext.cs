using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVC_Movies_CRUD.Models;

namespace MVC_Movies_CRUD.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext (DbContextOptions<MovieDbContext> options)
            : base(options)
        {
        }

        public DbSet<MVC_Movies_CRUD.Models.Movie> Movie { get; set; }
    }
}
