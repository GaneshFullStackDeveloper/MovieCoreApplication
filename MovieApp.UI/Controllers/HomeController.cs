using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using MovieApp.UI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Index(Test test)
        {
            var data = ViewBag.list;
            return View();
        }
        public IActionResult Index()
        {
            //List<SelectListItem> selectListItems = new List<SelectListItem>();
            //SelectListItem selectListItem = new SelectListItem();
            //selectListItem.Text = "Test";
            //selectListItem.Value = "1";
            //selectListItems.Add(selectListItem);
            //selectListItem = new SelectListItem();
            //selectListItem.Text = "Test1";
            //selectListItem.Value = "2";
            //selectListItems.Add(selectListItem);
            //selectListItem = new SelectListItem();
            //selectListItem.Text = "Test2";
            //selectListItem.Value = "3";
            //selectListItems.Add(selectListItem);
            //ViewBag.list = selectListItems;
            return View();//return html result
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
    public class Test
    {
        public int TestID { get; set; }
    }
}
