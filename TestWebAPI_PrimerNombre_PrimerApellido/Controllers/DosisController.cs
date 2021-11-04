using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebAPI_PrimerNombre_PrimerApellido.Controllers
{
    public class DosisController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
