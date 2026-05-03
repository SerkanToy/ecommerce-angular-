using ecommerce.api.Models.Domain.Abstractions;
using System;
using System.Collections.Generic;

namespace ecommerce.api.Models.Domain.Entities.Employees.Address
{
    public class Country : Entity
    {
        public Country()
        {
            Id = Guid.CreateVersion7();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<City> City { get; set; }
        public ICollection<Address> Address { get; set; }
    }
}
