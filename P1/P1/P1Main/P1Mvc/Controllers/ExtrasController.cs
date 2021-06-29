using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P1Mvc.Controllers
{
    public class ExtrasController : Controller
    {
        public IActionResult ExtrasMenu()
        {
            return View();
        }
    }
}
