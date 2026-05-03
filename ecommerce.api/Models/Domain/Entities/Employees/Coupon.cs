using ecommerce.api.Models.Domain.Abstractions;
using System;
using System.Collections.Generic;

namespace ecommerce.api.Models.Domain.Entities.Employees
{
    public class Coupon: Entity
    {
        public Coupon()
        {
            Id = Guid.CreateVersion7();
        }
        public Guid Id { get; set; }
        public ICollection<ProductJoinCoupon> ProductJoinCoupons { get; set; }
    }
}
