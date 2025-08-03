using Dashboard.Application.DTOs.Customers;
using Dashboard.Domain.Entities;
using Dashboard.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Application.Interfaces
{
    public interface ICustomerRepository
    {
        Task<CustomerDto> GetByIdAsync(int id);

        Task<IEnumerable<Customer>> GetAllAsync();
    }
}
