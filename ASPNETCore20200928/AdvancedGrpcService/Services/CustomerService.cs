using AdvancedGrpcService.Converter;
using AdvancedGrpcService.Data;
using AdvancedGrpcService.Protos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedGrpcService.Services
{
    public class CustomerService : Customer.CustomerBase // Customer.CustomerBase wurde generiert 
    {
        private readonly CustomerDbContext _dbContext;

        public CustomerService(CustomerDbContext customerDbContext)
        {
            _dbContext = customerDbContext;
        }


        public override async Task<Empty> WriteCustomer(NewCustomerModel request, ServerCallContext context)
        {
            try
            {
                Domain.Entities.Customer customer = request.ConvertToEntity();

                await _dbContext.AddAsync(customer);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }


            return new Empty();
        }



        public override async Task GetAllCustomer(Empty request, IServerStreamWriter<CustomerModel> responseStream, ServerCallContext context)
        {
            var customers = await _dbContext.Cutomers.ToListAsync();

            CustomerModel[] customerModels = customers.ToArray().ConvertToModels();

            foreach (CustomerModel currentModel in customerModels)
            {
                await responseStream.WriteAsync(currentModel);
            }
        }



        public override Task<CustomerModel> GetCustomer(CustomerRequest request, ServerCallContext context)
        {
            var currentCustomer = _dbContext.Cutomers.SingleOrDefault(n => n.Id == request.Id);

            CustomerModel customerModel = new CustomerModel();
            customerModel = currentCustomer.ConvertToModel();

            return Task.FromResult(customerModel);
        }
    }



    //public static MockDB {


}
