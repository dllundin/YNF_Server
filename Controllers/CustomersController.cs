using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YNF_Server.DB;
using YNF_Server.Models;
using YNF_Server.Utils;

namespace YNF_Server.Controllers
{

    [Produces("application/json")]
    [Route("api/Customers")]
    public class CustomersController : Controller
    {
        private readonly ICustomerRepository _CustomerRepository;

        public CustomersController(ICustomerRepository CustomerRepository)
        {
            _CustomerRepository = CustomerRepository;
        }

        // GET: api/Customers
        [NoCache]
        [HttpGet]
        public async Task<IEnumerable<Customer>> Get()
        {
            return await _CustomerRepository.GetAll();
        }

        // GET: api/Customers/5
        [NoCache]
        [HttpGet("{id}", Name = "Get")]
        public async Task<Customer> Get(int id)
        {
            return await _CustomerRepository.Get(id);
        }

        // POST: Create: api/Customers
        [HttpPost]
        public void Post([FromBody]Customer value)
        {
            _CustomerRepository.Create(new Customer
            {
                ID = value.ID,
                F_Name = value.F_Name,
                L_Name = value.L_Name,
                DOB = value.DOB,
                Email = value.Email,
                Address = value.Address,
                Phone = value.Phone,
                Stateid_ID = value.Stateid_ID,
                Stateid_Type = value.Stateid_Type,
                Notes = value.Notes,
                Image_ID = value.Image_ID,
                Created_On = DateTime.Now,
                Updated_On = DateTime.Now
            });
        }

        // PUT: Update: api/Customers/5
        [HttpPut("{id}")]
        public void Put([FromBody]Customer value)
        {
            _CustomerRepository.Update(value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _CustomerRepository.Delete(id);
        }
    }
}
