using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdvancedGrpcClient_MVC.Data;
using Domain.Entities;
using Grpc.Net.Client;
using AdvancedGrpcService.Protos;
using Grpc.Core;
using AdvancedGrpcClient_MVC.Converter;

namespace AdvancedGrpcClient_MVC.Controllers
{
    public class CustomerController : Controller
    {
       

        public CustomerController(AdvancedGrpcClient_MVCContext context)
        {
           
        }

        // GET: Customer
        public async Task<IActionResult> Index()
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var customerClient = new AdvancedGrpcService.Protos.Customer.CustomerClient(channel);

            List<CustomerModel> customerModels = new List<CustomerModel>();
            
            using (var getCustomerCall = customerClient.GetAllCustomer(new Google.Protobuf.WellKnownTypes.Empty()))
            {
                await foreach (var currentCust in getCustomerCall.ResponseStream.ReadAllAsync())
                {
                    customerModels.Add(currentCust);
                }
            }
            
            return View(customerModels.ToArray().ConvertToEntites());
        }

        // GET: Customer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var customerClient = new AdvancedGrpcService.Protos.Customer.CustomerClient(channel);

            CustomerRequest request = new CustomerRequest();
            request.Id = id.Value;

            var customerResponse = await customerClient.GetCustomerAsync(request);



            if (customerResponse == null)
            {
                return NotFound();
            }

            return View(customerResponse.ConvertToEntity());
        }

        // GET: Customer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,FirstName,LastName,Birthday")] Domain.Entities.Customer customer)
        {
            if (ModelState.IsValid)
            {

                var channel = GrpcChannel.ForAddress("https://localhost:5001");
                var customerClient = new AdvancedGrpcService.Protos.Customer.CustomerClient(channel);




                NewCustomerModel newCustomerModel = new NewCustomerModel();
                newCustomerModel.Title = Title.Dr;
                newCustomerModel.FirstName = "Dieter";
                newCustomerModel.LastName = "Mustermann";
                newCustomerModel.Birthday = DateTime.Now.ToShortDateString();

                var result = await customerClient.WriteCustomerAsync(newCustomerModel);


                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var customerClient = new AdvancedGrpcService.Protos.Customer.CustomerClient(channel);

            CustomerRequest request = new CustomerRequest();
            request.Id = id.Value;

            var customerResponse = await customerClient.GetCustomerAsync(request);

            if (customerResponse == null)
            {
                return NotFound();
            }
            return View(customerResponse.ConvertToEntity());
        }

        // POST: Customer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,FirstName,LastName,Birthday")] Domain.Entities.Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                }
                catch (DbUpdateConcurrencyException)
                {

                }
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var customerClient = new AdvancedGrpcService.Protos.Customer.CustomerClient(channel);

            CustomerRequest request = new CustomerRequest();
            request.Id = id.Value;

            var customerResponse = await customerClient.GetCustomerAsync(request);


            return View(customerResponse.ConvertToEntity());
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            return RedirectToAction(nameof(Index));
        }


    }
}
