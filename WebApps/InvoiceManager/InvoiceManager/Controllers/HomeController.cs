using InvoiceManager.Models.Domains;
using InvoiceManager.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvoiceManager.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Invoice(int id = 0)
        {
            EditInvoiceViewModel model = null;

            if (id == 0)
            {
                model = new EditInvoiceViewModel
                {
                    Clients = new List<Client> { new Client { Id = 1, Name = "Klient1" } },
                    MethodOfPayments = new List<MethodOfPayment> { new MethodOfPayment { Id = 1, Name = "Przelew" } },
                    Heading = "Edycja fakttury",
                    Invoice = new Invoice()
                };
            }
            else
            {
                model = new EditInvoiceViewModel
                {
                    Clients = new List<Client> { new Client { Id = 1, Name = "Klient1" } },
                    MethodOfPayments = new List<MethodOfPayment> { new MethodOfPayment { Id = 1, Name = "Przelew" } },
                    Heading = "Edycja fakttury",
                    Invoice = new Invoice
                    {
                        ClientId = 1,
                        Comments = "wwwww",
                        CreateDate = DateTime.Now,
                        PaymentDate = DateTime.Now,
                        MethodOfPaymentId = 1,
                        Id = 1,
                        Value = 100,
                        Title = "FA/10/2020",
                        InvoicePositions = new List<InvoicePosition> 
                        {
                            new InvoicePosition
                            {
                                Id = 1,
                                Lp = 1,
                                Product = new Product { Name = "Produkt" },
                                Quantity = 2,
                                Value = 50
                            },
                            new InvoicePosition
                            {
                                Lp = 2,
                                Product = new Product { Name = "Produkt2" },
                                Quantity = 3,
                                Value = 510
                            }
                        }
                    }
                };
            }

            return View(model);
        }

        public ActionResult InvoicePosition(int invoiceId, int invoicePositionId = 0)
        {
            EditInvoicePositionViewModel model = null;

            if (invoicePositionId == 0)
            {
                model = new EditInvoicePositionViewModel
                {
                    InvoicePosition = new InvoicePosition(),
                    Heading = "Dodawanie nowej pozycji",
                    Products = new List<Product> { new Product { Id = 1, Name = "Produkt 1" } }
                };
            }
            else
            {
                model = new EditInvoicePositionViewModel
                {
                    InvoicePosition = new InvoicePosition 
                    { 
                        Lp = 1, Value = 100, Quantity = 2, ProductId = 1
                    },
                    Heading = "Dodawanie nowej pozycji",
                    Products = new List<Product> { new Product { Id = 1, Name = "Produkt 1" } }
                };
            }

            return View(model);
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}