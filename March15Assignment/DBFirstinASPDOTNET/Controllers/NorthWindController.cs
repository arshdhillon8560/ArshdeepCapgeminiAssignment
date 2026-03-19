using Microsoft.AspNetCore.Mvc;
using DBFirstinASPDOTNET.Models;
using System.Reflection;
using System.Security.Cryptography.Xml;

namespace DBFirstinASPDOTNET.Controllers
{
    public class NorthWindController : Controller
    {

        
        public IActionResult SpainCustomers()
        {
            NorthWindContext context = new NorthWindContext();
            var spaincustomers = context.Customers.Where(x => x.Country == "Spain").Select(x => new Customer
            {
             CustomerId = x.CustomerId,
             ContactName = x.ContactName,
             CompanyName=x.CompanyName
            }).ToList();
            return View(spaincustomers);
        }


        public IActionResult searchCustomer(string contactname)
        {
            NorthWindContext cnt = new NorthWindContext();
            var searchcustomer = cnt.Customers.Where(x => x.ContactName == contactname).Select(x=> new Customer
            {
                ContactName = x.ContactName,
                ContactTitle = x.ContactTitle,
                CompanyName = x.CompanyName,

            });
            var query1 = searchcustomer.Single();
            return View(query1);
        }

        public ActionResult ProductsInCategory(string categoryname)
        {
            NorthWindContext cnt = new NorthWindContext();

            if (string.IsNullOrEmpty(categoryname))
            {
                return View(new List<ProdCat>());
            }

            var productsinCategory = cnt.Products
                .Where(x => x.Category.CategoryName.ToLower().Contains(categoryname.ToLower()))
                .Select(x => new ProdCat
                {
                    prodname = x.ProductName,
                    catname = x.Category.CategoryName
                }).ToList();

            return View(productsinCategory);
        }

        public ActionResult OrderRange(string range)
        {
            NorthWindContext cnt = new NorthWindContext();
            var range1 = Convert.ToInt16(range);
            var custOrderCount = cnt.Customers.Where(x => x.Orders.Count > range1).Select(x => new Customer
            {
               CustomerId=x.CustomerId,
               ContactName=x.ContactName,
               
            });

            return View(custOrderCount);
        }


        public ActionResult CustomerOrderDetails(string id)
        {
            NorthWindContext cnt = new NorthWindContext();
            var orders = cnt.Orders.Where(o => o.CustomerId == id)
                        .Select(o => new Order
                        {
                            OrderId = o.OrderId,
                            OrderDate = o.OrderDate,
                        }).ToList();

            return View(orders);
        }
    }
}
