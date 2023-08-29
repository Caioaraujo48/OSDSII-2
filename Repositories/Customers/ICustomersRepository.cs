using OsDsII.api.Models;

namespace OsDsII.api.Repositories.Interfaces;
{
    public interface ICustomersRepository
    {
        public Task<IEnumerable<Customers>> GetAllCustomersAsync();
        public Task<Customers> GetCustomerByIdAsync(int id);
        public Task<Customers> CreateCustomerAsync(Customers newCustomer);
        public Task<Customers> UpdateCustomerAsync(int id, Customers customer);
        public Task<Customers> DeleteCustomerAsync(int id);
    }
}