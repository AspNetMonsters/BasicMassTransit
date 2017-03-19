using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MassTransit;
using Common.Messages.Commands;

namespace masstransit2.Controllers
{
    public class HomeController : Controller
    {
        IBus _bus;
        public HomeController(IBus bus)
        {
            _bus = bus;
        }
        public async Task<IActionResult> Index()
        {
            var addUserEndpoint = _bus.GetSendEndpoint(new Uri("rabbitmq://172.22.149.120/AddUser1"));
            await (await addUserEndpoint).Send<AddUser>(new 
            {
                FirstName = "Simon",
                LastName="Tibbs",
                EmailAddress="stimms@gmail.com",
                Password = "A wicked secret password"
            });
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
