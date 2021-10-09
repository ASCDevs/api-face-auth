using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace api_face_auth.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FaceController : Controller
    {
        [HttpGet]
        public JsonResult statusFaces()
        {
            var dados = new { 
                imgsCadastradas = 0,
                dataStatus = DateTime.Now,
                quatidadeUsers = 0
            };

            return Json(dados);
        }

        [HttpPost("register")]
        public JsonResult registerFace([FromForm] IFormFile imagem)
        {
            Console.WriteLine("Imagem recebida");
            return Json(new { message = "Cadastro do Rosto do usuário em construção"});
        }

        [HttpGet("consultar/{id}")]
        public JsonResult GetFace(int id)
        {

            return Json(new { idRecebido = id, message="Esta rota irá consultar o rosto de id "+id+""});
        }

        [HttpGet("excluir/{id}")]
        public JsonResult DelFace(int id){
            return Json(new {idRecebido = id, message= "Esta rota irá excluir o rosto de id "+id+""});
        }
    }
}
