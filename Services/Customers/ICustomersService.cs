using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OsDsII.api.Models;

namespace OsDsII.api.Services.Interfaces
{
    public interface ICustomersService
    {
        public Task<IEnumerable<Customer>> GetAllCustomersAsync();
        public Task<Customers> GetCustomerByIdAsync(int id);
        public Task<Customers> CreateCustomerAsync([FromBody] Customer newCustomer);
        public Task<Customers> UpdateCustomerAsync(int id, [FromBody] Customer customer);
        public Task<Customers> DeleteCustomerAsync(int id);
    }
}