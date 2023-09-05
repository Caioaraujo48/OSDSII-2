using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OsDsII.api.Models;
using OsDsII.api.Repositories.UnitOfWork;

namespace OsDsII.api.Services
{
    public class CustomersService : ICustomersService
    {
        private readonly DataContext _context;
        private readonly ICustomersRepository _customersRepository;

        public CustomersService(DataContext context, ICustomersRepositoy customersRepository, IUnitOfWork unitOfWork)
        {
            _context = context;
            _customersRepository = customersRepository;
            _unitOfWork = unitOfWork;
        } 

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            IEnumerable<Customer> customers = await _customersRepository.GetAllCustomersAsync();
            return customers;
        }
        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            Customer customer = await _customersRepository.GetCustomerByIdAsync(id);
            
            if (customer == null)
            {
                throw new Exception("Não encontrado");
            }
            return customer;
        }

        public async Task<Customer> CreateCustomerAsync([FromBody] Customer newCustomer)
        {
            Customer currentCustomer = await _customersRepository.CreateCustomerAsync(newCustomer);

            if (currentCustomer != null)
            {
                throw new Exception("Usuário já existe");
            }
            await _unitOfWork.SaveChangesAsync();
            await _customersRepository.CreateCustomersAsync(newCustomer);
            return currentCustomer;
        }

        public async Task<Customer> UpdateCustomerAsync(int id, [FromBody] Customer customer)
        {
            Customer currentCustomer = await _customersRepository.UpdateCustomerAsync(id, customer);
            if (currentCustomer == null)
            {
                throw new Exception("Não encontrado");
            }

            currentCustomer.Name = customer.Name;
            currentCustomer.Email = customer.Email;
            currentCustomer.Phone = customer.Phone;

            await _unitOfWork.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> DeleteCustomerAsync(int id)
        {
            Customer customer = await _customersRepository.DeleteCustomerAsync(id);

            if (customer == null)
            {
                throw new Exception("Não encontrado");
            }

            return customer;
        }
    }
}