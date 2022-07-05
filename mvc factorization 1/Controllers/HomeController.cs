using Microsoft.AspNetCore.Mvc;
using mvc_factorization_1.Models;
using System.Diagnostics;
using System.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace mvc_factorization_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GetFactorization(string numToFactorize = "")
        {
            Number n = JsonConvert.DeserializeObject<Number>(numToFactorize);
            int num = n.Value;
            int b;
            string result = "";
            int count = 0;
            int flag = 0;
            int i, j;
            for (i = 2; i < num; i++)
            {
                // check for divisibility
                if (num % i == 0)
                {
                    count = 0;
                    // check for prime number
                    for (j = 1; j <= i; j++)
                    {
                        if (i % j == 0)
                            count++;
                    }
                    if (count == 2)
                    {
                        flag = 1;
                        //Console.Write(i + " ");
                        result = result + " " + i + " ";
                    }
                }
            }
            if (flag == 0)
            {
                result = "There is no Prime factor for " + num;
            }

            List<string> res = result.Split(' ').ToList();
            return Json(res);
        }

        public class Number
        {
            public int Value { get; set; }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}