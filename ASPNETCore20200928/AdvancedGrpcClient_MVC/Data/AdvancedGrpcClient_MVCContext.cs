using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace AdvancedGrpcClient_MVC.Data
{
    public class AdvancedGrpcClient_MVCContext : DbContext
    {
        public AdvancedGrpcClient_MVCContext (DbContextOptions<AdvancedGrpcClient_MVCContext> options)
            : base(options)
        {
        }

        public DbSet<Domain.Entities.Customer> Customer { get; set; }
    }
}
