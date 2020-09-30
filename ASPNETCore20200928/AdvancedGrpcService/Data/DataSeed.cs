using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedGrpcService.Data
{
    public class DataSeed
    {

        /// <summary>
        /// Initializes the specified service provider.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        public static void Initialize(IServiceProvider serviceProvider)
        {

            using (var context = new CustomerDbContext(serviceProvider.GetRequiredService<DbContextOptions<CustomerDbContext>>()))
            {
                try
                {
                    if (context.Cutomers.Count() == 0)
                    {
                        Domain.Entities.Customer customer1 = new Domain.Entities.Customer();
                        customer1.FirstName = "Max";
                        customer1.LastName = "Mustermann";
                        customer1.Title = 1;
                        customer1.Birthday = DateTime.Now;

                        Domain.Entities.Customer customer2 = new Domain.Entities.Customer();
                        customer2.FirstName = "Martin";
                        customer2.LastName = "Muster";
                        customer2.Title = 0;
                        customer2.Birthday = DateTime.Now;

                        Domain.Entities.Customer customer3 = new Domain.Entities.Customer();
                        customer3.FirstName = "Eddi";
                        customer3.LastName = "Murphy";
                        customer3.Title = 2;
                        customer3.Birthday = DateTime.Now;

                        Domain.Entities.Customer customer4 = new Domain.Entities.Customer();
                        customer4.FirstName = "RockMe";
                        customer4.LastName = "Amadeus";
                        customer4.Title = 2;
                        customer4.Birthday = DateTime.Now;

                        context.Add(customer1);
                        context.Add(customer2);
                        context.Add(customer3);
                        context.Add(customer4);

                        context.SaveChanges();
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}
