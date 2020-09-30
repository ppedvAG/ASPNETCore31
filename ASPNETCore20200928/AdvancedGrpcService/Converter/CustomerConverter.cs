using AdvancedGrpcService.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedGrpcService.Converter
{
    public static class CustomerConverter
    {
        public static CustomerModel ConvertToModel(this Domain.Entities.Customer customer)
        {
            CustomerModel customerModel = new CustomerModel();
            customerModel.Id = customer.Id.ToString();
            customerModel.FirstName = customer.FirstName;
            customerModel.LastName = customer.LastName;
            customerModel.Birthday = customer.Birthday.ToString();
            customerModel.Title = (Title)customer.Title;

            return customerModel;
        }
        public static CustomerModel[] ConvertToModels(this Domain.Entities.Customer[] customer)
        {
            List<CustomerModel> customerModels = new List<CustomerModel>();

            foreach (Domain.Entities.Customer currentCustomer in customer)
            {
                customerModels.Add(currentCustomer.ConvertToModel());
            }
            return customerModels.ToArray();
        }


        public static Domain.Entities.Customer ConvertToEntity(this CustomerModel model)
        {
            Domain.Entities.Customer customer = new Domain.Entities.Customer();

            customer.FirstName = model.FirstName;
            customer.LastName = model.LastName;
            customer.Birthday = Convert.ToDateTime(model.Birthday);
            customer.Title = (int)model.Title;


            return customer;
        }
        public static Domain.Entities.Customer[] ConvertToEntites(this CustomerModel[] model)
        {
            List<Domain.Entities.Customer> customerModels = new List<Domain.Entities.Customer>();

            foreach (CustomerModel currentModel in model)
            {
                customerModels.Add(currentModel.ConvertToEntity());
            }
            return customerModels.ToArray();
        }

        public static Domain.Entities.Customer ConvertToEntity(this NewCustomerModel model)
        {
            Domain.Entities.Customer customer = new Domain.Entities.Customer();
            customer.FirstName = model.FirstName;
            customer.LastName = model.LastName;
            customer.Birthday = Convert.ToDateTime(model.Birthday);
            customer.Title = (int)model.Title;


            return customer;
        }
        public static Domain.Entities.Customer[] ConvertToEntites(this NewCustomerModel[] model)
        {
            List<Domain.Entities.Customer> customerModels = new List<Domain.Entities.Customer>();

            foreach (NewCustomerModel currentModel in model)
            {
                customerModels.Add(currentModel.ConvertToEntity());
            }
            return customerModels.ToArray();
        }


    }
}
