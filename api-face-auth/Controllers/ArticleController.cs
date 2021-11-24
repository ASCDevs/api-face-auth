using api_face_auth.DataSqlite.Manager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_face_auth.Controllers
{
    [Route("article")]
    [ApiController]
    public class ArticleController : Controller
    {
        private readonly ContextManager _manager;

        public ArticleController(ContextManager manager)
          {
            _manager = manager;
        }

        [HttpPost("create")]
        public ActionResult createArticle()
        {
            try
            {

            }
            catch (Exception e)
            {

                return Json(new { message = e.Message});
            }
            return Ok(Json(new { message = "Artigo cadastrado com sucesso!" }));
        }
    }
}
