using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using QuotesFinal.Models;

namespace QuotesFinal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationContext daContext { get; set; }

        public HomeController(ILogger<HomeController> logger, ApplicationContext someName)
        {
            _logger = logger;
            daContext = someName;
        }

        public IActionResult Index()
        {
            var quotes = daContext.responses.OrderBy(x => x.Author).ToList();
            return View(quotes);
        }

        [HttpGet]

        public IActionResult Details(int applicationid)
        {
            var quote = daContext.responses.Where(x => x.QuoteId == applicationid);

            return View(quote);
        }


        [HttpGet]

        public IActionResult RandomQuote()
        {
            Random rnd = new Random();
            int value = rnd.Next(1,daContext.responses.Count()-1);
            var quote = daContext.responses.Where(x => x.QuoteId == value);

            return View("Details", quote);
        }


        [HttpGet]

        public IActionResult Quote()
        {

            return View();
        }

        [HttpPost]

        public IActionResult Quote(QuoteResponse ar)
        {
            if (ModelState.IsValid)
            {
                daContext.Add(ar);
                daContext.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(ar);
            }
        }

        [HttpGet]
        public IActionResult Edit(int applicationid)
        {
            var application = daContext.responses.Single(x => x.QuoteId == applicationid);

            return View("Quote", application);
        }

        [HttpPost]

        public IActionResult Edit(QuoteResponse blah)
        {
            daContext.Update(blah);
            daContext.SaveChanges();
            return RedirectToAction("Index");

        }


        [HttpGet]

        public IActionResult Delete(int applicationid)
        {

            var application = daContext.responses.Single(x => x.QuoteId == applicationid);

            return View(application);
        }

        [HttpPost]
        public IActionResult Delete(QuoteResponse ar)
        {
            daContext.responses.Remove(ar);
            daContext.SaveChanges();

            return RedirectToAction("Index");
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
