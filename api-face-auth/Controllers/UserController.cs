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
using api_face_auth.DataSqlite.Manager;

namespace api_face_auth.Controllers
{    
    [ApiController]
    [Route("user")]
    public class UserController : Controller
    {
        private readonly ContextManager _manager;

        public UserController(ContextManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public ActionResult getUsers()
        {
            return Ok();
        }

        [HttpPost("register")]
        public ActionResult registerUser(UserRegisterModel newUser)
        {
            try
            {
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


                    int idUser = _manager.CreateUser(newUserDb);
                    List<UserFace> faceInfoList = new List<UserFace>();

                    foreach (var faceString in newUser.imagesBase64)
                    {
                        string[] imageData = faceString.Split(',');

                        faceInfoList.Add(new UserFace
                        {
                            iduser = idUser,
                            image = Convert.FromBase64String(imageData[1])
                        });

                    }

                    _manager.CreateUserFaceInfo(faceInfoList);
                }
                else
                {
                    return BadRequest(Json(new { message = "Usuário a ser cadastrado é inválido" }));
                }

            }
            catch (Exception e)
            {
                //Implementar Status Code
                return (Json(new { message = e.Message}));
            }
            

            return Ok(Json(new { message = "Usuário cadastrado com sucesso!"}));
        }

        

        [HttpGet("find/{id}")]
        public JsonResult getUser(int id)
        {

            return Json(new { idRecebido = id, message="Esta rota irá consultar o rosto de id "+id+""});
        }

        [HttpPost("delete/{id}")]
        public JsonResult deleteUser(int id){
            return Json(new {idRecebido = id, message= "Esta rota irá excluir o rosto de id "+id+""});
        }

        
    }
}
