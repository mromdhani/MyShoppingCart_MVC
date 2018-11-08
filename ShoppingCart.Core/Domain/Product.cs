﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Core.Domain
{
    public class Product
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        [DisplayName("Photo")]
        public string PhotoFile { get; set; }
        public decimal UnitPrice { get; set; }

        // override object.Equals
        public override bool Equals(object obj)
        {      
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return ((Product)obj).ProductId.Equals(ProductId);
         
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return ProductId.GetHashCode();
        }
    }
}
