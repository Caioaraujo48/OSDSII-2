using OsDsII.api.Models;

namespace OsDsII.api.Repositories.Interfaces;
{
    public interface ICustomersRepository
    {
        public Task<IEnumerable<Customer>> GetAllCustomersAsync();
        public Task<Customer> GetCustomerByIdAsync(int id);
        public Task<Customer> CreateCustomerAsync(Customer newCustomer);
        public Task<Customer> UpdateCustomerAsync(int id, Customer customer);
        public Task<Customer> DeleteCustomerAsync(int id);
    }
}