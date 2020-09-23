using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AjaxDB2.Models;

namespace AjaxDB2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AjaxDB2Context _context;

        public HomeController(ILogger<HomeController> logger, AjaxDB2Context context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {

            var divlist = _context.DivLists.OrderBy(d => d.Name);
            ViewBag.dv = divlist;
            return View();
        }
        
        public JsonResult getDistrict(int id)
        {
            var dislist = _context.Districts.Where(d=> d.DivListId==id).OrderBy(d => d.Name);
          
            return Json(dislist);
        }

        public JsonResult getUpazila(int id)
        {
            var upzlist = _context.Upazilas.Where(a=> a.DistrictId==id).OrderBy(d => d.Name);
     
            return Json(upzlist);
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
