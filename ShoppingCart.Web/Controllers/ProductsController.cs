using ShoppingCart.Core.Domain;
using ShoppingCart.Core.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCart.Web.Controllers
{
    public class ProductsController : Controller
    {
        private IProductsRepository repo;  // Injecté par Unity

        public ProductsController(IProductsRepository repo)
        {
            this.repo = repo;
        }
        public ActionResult Index()
        {
            return View(repo.FindAll());
        }

        public ActionResult AddToCart(string id)
        {

            List<Item> panier = null;
            Product produit = repo.FindAll().FirstOrDefault(p => p.ProductId.Equals(id));
            if (Session["cart"] ==  null)
            {
                panier = new List<Item> {
                    new Item { Product= produit, Quantity=1} 
                };
                Session["cart"] = panier;

            }else
            {
                panier = (List<Item>)Session["cart"];

                Item p = panier.Find(i => i.Product.ProductId.Equals(id));
           
                if (p == null )  // Le produit n'existe pas dans le panier
                {
                    panier.Add(new Item {Product=produit, Quantity=1 });
                    Session["cart"] = panier;
                }
                else
                {
                    p.Quantity++;
                    Session["cart"] = panier;

                }
            }
            return View("Panier", panier);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}