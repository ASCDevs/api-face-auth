using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_face_auth.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        //Responsável em carrega a tela de Login na View

        
        public IActionResult Index()
        {
            return View();
        }
    }
}
