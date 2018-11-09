using Moq;
using ShoppingCart.Core.Domain;
using ShoppingCart.Core.Facade;
using System.Collections.Generic;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace ShoppingCart.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            var mockProducts = new Mock<IProductsRepository>();
            mockProducts.Setup(m => m.FindAll()).Returns(
                new List<Product> {
                    new Product {ProductId="P1000", Name="Café", PhotoFile="cafe.png", UnitPrice=1.5M  },
                    new Product {ProductId="P2000", Name="The", PhotoFile="the.jpg", UnitPrice=1.5M  },
                    new Product {ProductId="P3000", Name="Chocolat", PhotoFile="chocolat.jpg", UnitPrice=1.5M  },
                    new Product {ProductId="P4000", Name="Gateaux", PhotoFile="cake.jpg", UnitPrice=1.5M  },

                }
            );
            container.RegisterInstance<IProductsRepository>(mockProducts.Object);

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}