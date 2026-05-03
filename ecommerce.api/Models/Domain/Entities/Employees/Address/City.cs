using ecommerce.api.Models.Domain.Abstractions;
using System;
using System.Collections.Generic;

namespace ecommerce.api.Models.Domain.Entities.Employees.Address
{
    public class City : Entity
    {
        public City()
        {
            Id = Guid.CreateVersion7();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CountryId { get; set; }
        public Country Country { get; set; }
        public ICollection<Town> Town { get; set; }
        public ICollection<Address> Address { get; set; }
    }
}
