﻿using ShoppingCart.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Core.Facade
{
    public interface IProductsRepository
    {
        // CRUD
        IEnumerable<Product> FindAll();

    }
}
