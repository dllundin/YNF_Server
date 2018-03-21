using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YNF_Server.Models;

namespace YNF_Server.DB
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAll();
        Task<Customer> Get(int ID);
        Task Create(Customer customer);
        Task<bool> Delete(int ID);
        Task<bool> Update(Customer customer);
        Task<bool> RemoveAll();
    }
}
