using Dashboard.Application.DTOs.Customers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Application.Queries.Customer
{
    public sealed record  GetAllCustomersQuery() : IRequest<List<CustomerDto>?>;

}
