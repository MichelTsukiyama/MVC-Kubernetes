using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using frontend.Models;
using frontend.Services;

namespace frontend.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPizzaService _pizza;
        public IEnumerable<PizzaInfo> Pizzas;

        public HomeController(ILogger<HomeController> logger, IPizzaService pizza)
        {
            _logger = logger;
            _pizza = pizza;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult GetPizzas()
        {
            Pizzas = _pizza.GetPizzas();

            if (Pizzas is null)
                return View("Error");
                
            return View(Pizzas);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
