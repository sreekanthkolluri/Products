using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Products.UI.Models;

namespace Products.UI.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {

        }

        public IActionResult Index()
        {
            IEnumerable<ProductViewModel> products = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:57689/Product/api/");
                var responseTask = client.GetAsync("GetProducts");
                responseTask.Wait();
                //To store result of web api response.   
                var result = responseTask.Result;
                //If success received   
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<ProductViewModel>>();
                    readTask.Wait();
                    products = readTask.Result;
                }
                else
                {
                    //Error response received   
                    products = Enumerable.Empty<ProductViewModel>();
                    ModelState.AddModelError(string.Empty, "Tray again...");
                }
            }
            return View(products);
        }
    }
}
