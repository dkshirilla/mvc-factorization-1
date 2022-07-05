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
        public IActionResult Index()
        {
            return View();
        }

        private Numz _number;
        public HomeController()
        {
            _number = new Numz();
        }

        [HttpPost]
        public JsonResult GetFactorization(string numToFactorize = "")
        {
            _number = JsonConvert.DeserializeObject<Numz>(numToFactorize);
            int num = _number.Value;
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
                //result = "There is no Prime factor for " + num;
                return Json("none");
            }
            else
            {
                List<string> res = result.Split(' ').ToList();
                res.RemoveAll(s => s == "");
                return Json(res);
            }
        }
    }
}