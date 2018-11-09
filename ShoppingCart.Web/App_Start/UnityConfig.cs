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

            var repoMock = new Mock<IProductsRepository>();
            repoMock.Setup(o => o.FindAll()).Returns(
                new List<Product> {
                    new Product {ProductId= "P001",Name="Cafe", PhotoFile="Cafe.png", UnitPrice=1.2M },
                    new Product {ProductId= "P002",Name="Cake", PhotoFile="cake.png", UnitPrice=1.2M },
                    new Product {ProductId= "P003",Name="Chocolat", PhotoFile="chocolat.jpg", UnitPrice=1.2M },
                     new Product {ProductId= "P004",Name="The", PhotoFile="tea.jpg", UnitPrice=1.2M },
                });
            container.RegisterInstance<IProductsRepository>(repoMock.Object);
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}