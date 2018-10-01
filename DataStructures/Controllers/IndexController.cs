using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructures.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            Queue<string> inLine = new Queue<string>();
            for (int i = 0; i < 100; i++)
            {
                inLine.Enqueue(randomName());
            }

            Dictionary<string, int> customers = new Dictionary<string, int>();
            //foreach (string customer in inLine)
            while (inLine.Count > 0)
            {
                string customer = inLine.Dequeue();
                if (customers.ContainsKey(customer))
                {
                    customers[customer] += randomNumberInRange();
                } else
                {
                    customers.Add(customer, randomNumberInRange());
                }
            }

            ViewBag.Table = "<table class=\"table table-striped\"><tr><th>Customer Name</th><th>Burgers Eaten</th></tr>";

            foreach (KeyValuePair<string, int> customer in customers)
            {
                ViewBag.Table += "<tr><td>" + customer.Key + "</td>";
                ViewBag.Table += "<td>" + customer.Value + "</td></tr>";
            }

            ViewBag.Table += "</table>";

            return View();
        }

        public static Random random = new Random();

        public static string randomName()
        {
            string[] names = new string[8] { "Dan Morain", "Emily Bell", "Carol Roche", "Ann Rose", "John Miller", "Greg Anderson", "Arthur McKinney", "Joann Fisher" };
            int randomIndex = Convert.ToInt32(random.NextDouble() * 7);
            return names[randomIndex];
        }

        public static int randomNumberInRange()
        {
            return Convert.ToInt32(random.NextDouble() * 20);
        }
    }
}