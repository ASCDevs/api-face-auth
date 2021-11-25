using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_face_auth.Controllers
{
    public class HomeController : Controller
    {
        //Resonsável pelo carregamento da Home na View
        public IActionResult Index()
        {
            return View();
        }
    }
}
