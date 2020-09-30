using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models;

namespace WebAPI_Basics.Data
{
    public class WebAPI_BasicsContext : DbContext
    {
        public WebAPI_BasicsContext (DbContextOptions<WebAPI_BasicsContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; }
    }
}
