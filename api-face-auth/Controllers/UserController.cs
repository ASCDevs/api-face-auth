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
using api_face_auth.DataSqlite;
using api_face_auth.DataSqlite.Entities;

namespace api_face_auth.Controllers
{    
    [ApiController]
    [Route("user")]
    public class UserController : Controller
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public ActionResult registerUser(UserRegisterModel newUser)
        {
            //Implementar tratamento de exceção
            if (ModelState.IsValid)
            {
                if (newUser == null)
                {
                    return BadRequest(Json(new { message = "Nenhum usuário a ser cadastrado" }));
                }

                User newUserDb = new User
                {
                    name = newUser.name,
                    surname = newUser.surname,
                    username = newUser.username,
                    password = newUser.password,
                    email = newUser.email,
                    registerDate = DateTime.Now
                };
                
              _context.Users.Add(newUserDb);
                int idUser = 0; //retornar do banco

                foreach(var faceString in newUser.imagesBase64)
                {
                    string[] imageData = faceString.Split(',');

                    _context.UsersFace.Add(new UserFace
                    {
                        iduser = idUser,
                        image = Convert.FromBase64String(imageData[1])
                    });

                }
                _context.SaveChanges();
            }
            else
            {
                return BadRequest(Json(new { message = "Usuário a ser cadastrado é inválido"}));
            }

            return Ok(Json(new { message = "Usuário cadastrado com sucesso!"}));
        }

        [HttpPost("register64")]
        public async Task<JsonResult> register64Face(UserRegisterModel newUser,[FromServices] AppDbContext context){

            var user = new User{
                nome = newUser.name,
                usuario = newUser.username,
                senha = newUser.password,
                email = newUser.email
            };

            int idUser = 0;

            try{
                await context.Users.AddAsync(user); //Salva só na memória
                await context.SaveChangesAsync(); //Salva no banco
                idUser = user.id;

            }catch(Exception e){
                Console.WriteLine("Erro criar user> "+e.Message);
            }
            
            
            List<FaceModel> faceImages = new List<FaceModel>();
            List<UserFace> userFaces = new List<UserFace>();

            foreach(var img in newUser.imagesBase64){
                string[] imgDados = img.Split(',');

                faceImages.Add(new FaceModel{
                    nomeId = Guid.NewGuid().ToString(),
                    dtCriacao = DateTime.Now,
                    metaDados = imgDados[0],
                    extensao = imgDados[0].Split(';')[0].Split('/')[1],
                    imagemBytes = Convert.FromBase64String(imgDados[1])
                });
            }

            foreach(var face in faceImages){
                Console.WriteLine("--");
                Console.WriteLine("NomeId> "+face.nomeId);
                Console.WriteLine("dtCriacao> "+face.dtCriacao);
                Console.WriteLine("metaDados> "+face.metaDados);
                Console.WriteLine("extensao> "+face.extensao);
                
                userFaces.Add(new UserFace{
                    iduser = idUser,
                    image = face.imagemBytes
                });
                //Faz upload das imagens na pasta
                // try{
                //     string caminho  = @"./Uploads/";
                //     DirectoryInfo dir = Directory.CreateDirectory(caminho);
                    
                //     string path = caminho+face.nomeId+"."+face.extensao; 

                //     using( var fs = new FileStream(path,FileMode.Create,FileAccess.Write)){
                //         fs.Write(face.imagemBytes,0,face.imagemBytes.Length);
                //     }

                // }catch(Exception e){
                //     Console.WriteLine("Erro: "+e.Message);
                // }
            }

            try{
                await context.UsersFace.AddRangeAsync(userFaces);
                await context.SaveChangesAsync();

            }catch(Exception e){
                Console.WriteLine("Erro cadastrar face> "+e.Message);
            }


            
            int qtdRecebida = newUser.imagesBase64.Count();

            Console.WriteLine("register64> Lista de FaceImages:"+faceImages.Count());
            Console.WriteLine("register64> quantidade de imgs: "+qtdRecebida);
            Console.WriteLine("register64> User id cadastrado: "+user.id);
            Console.WriteLine("---------------");

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
