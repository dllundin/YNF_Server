using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YNF_Server.DB;
using YNF_Server.Models;

namespace YNF_Server.Controllers
{
    [Produces("application/json")]
    [Route("api/System")]
    public class SystemController : Controller
    {

        private readonly ICustomerRepository _CustomerRepository;

        public SystemController(ICustomerRepository CustomerRepository)
        {
            _CustomerRepository = CustomerRepository;
        }
        [HttpGet("{setting}")]
        public async Task<string> Get(string setting)
        {
            if (setting == "init")
            {
                await _CustomerRepository.RemoveAll();

                for (int i = 0; i <= 10; i++)
                {
                    await _CustomerRepository.Create(new Customer
                    {
                        ID = i,
                        F_Name = $"F_Name_{i}",
                        L_Name = $"L_Name_{i}",
                        DOB = DateTime.Now.AddYears(-1 * i),
                        Email = $"Email_{i}",
                        Address = $"Address_{i}",
                        Phone = new string(i.ToString().ToCharArray()[0], 10),
                        Stateid_ID = new string(i.ToString().ToCharArray()[0], 10),
                        Stateid_Type = "Driving License",
                        Notes = " Notes Notes Notes  Notes Notes Notes  Notes Notes Notes  Notes Notes Notes  Notes Notes Notes  Notes Notes Notes ",
                        Image_ID = i,
                        Created_On = DateTime.Now,
                        Updated_On = DateTime.Now
                    });
                }

                return "Done";
            }

            return "Unknown";
        }
    }
}
