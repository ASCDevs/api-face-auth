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
        public JsonResult registerFace([FromForm] List<IFormFile> imagens)
        {
            //Fazer tratamento para validar extensão das imagens
            if(imagens.Count()==0){
                return Json(new {message="Nenhuma imagem recebida"});
            }
            int qtdRecebida = imagens.Count();
            List<string> nomesImgs = new List<string>();
            foreach (var img in imagens)
            {
                nomesImgs.Add(img.FileName);
            }

            Console.WriteLine($"Imagem recebida ({qtdRecebida})");
            return Json(new { qtdRecebida = qtdRecebida, nomes = nomesImgs.ToArray(), message = "Cadastro do Rosto do usuário em construção"});
        }

        [HttpPost("register64")]
        public JsonResult register64Face(string imagem){
            //Fazer tratamento para validar extensão das imagens
            if(imagens == null){
                Console.WriteLine("Requisição register64> nada recebido");
                return Json(new {message = "Parametro vazio"});
            }

            Byte[] bytesImg = Convert.FromBase64String(imagem);

            if(bytesImg.Length > 0){
                using (var stream = new FileStream(arquivo, FileMode.Create)){
                    stream.Write(bytesImg,0,bytesImg.Length);
                    stream.Flush();
                }
            }
            

            Console.WriteLine("Requisição register64 chegou no server");


            return Json(new { message = "Rota para receber imagens em base 64"});
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
