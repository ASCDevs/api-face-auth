using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text;
using api_face_auth.Models;

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
        public JsonResult register64Face(TesteModel conteudo){

            List<Byte[]> bytesImg = new List<byte[]>();

            foreach(var img in conteudo.imagens){
                 bytesImg.Add(Convert.FromBase64String(img));
             }

            Console.WriteLine("register64> Lista de bytes:"+bytesImg.Count());

            TesteController teste = new TesteController();
            
            // foreach(var dadosImgByte in bytesImg){
            //     //var path = HttpContext.Current.Server.MapPath("~/Uploads/"+Guid.NewGuid());
            //     var path = @"~/Uploads/"+Guid.NewGuid()+".jpg";
            //     File.WriteAllBytes(path, dadosImgByte);
            // }

           //if(bytesImg.Length > 0){
                // using (var stream = new FileStream(arquivo, FileMode.Create)){
                //     stream.Write(bytesImg,0,bytesImg.Length);
                //     stream.Flush();
                // }
            //}
            int qtdRecebida = conteudo.imagens.Count();

            Console.WriteLine("register64> quantidade de imgs: "+qtdRecebida);

            return Json(new {imsgQtd = qtdRecebida, message = "Rota para receber imagens em base 64"});
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
