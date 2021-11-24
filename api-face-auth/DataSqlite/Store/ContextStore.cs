using api_face_auth.DataSqlite.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_face_auth.DataSqlite.Store
{
    
    public class ContextStore
    {
        private readonly AppDbContext _context;
        public ContextStore(AppDbContext context)
        {
            _context = context;
        }


        public int CreateUser(User newUser)
        {
            try
            {
                _context.Users.Add(newUser);
                _context.SaveChanges();
                return newUser.idUser;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao cadastrar user: "+e.Message);
            }
        }

        public void CreateUserFaceInfo(List<UserFace> faceInfoList)
        {
            try
            {
                _context.UsersFace.AddRange(faceInfoList);
                _context.SaveChanges();

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao casdastar informações faciais: "+e.Message);
            }

        }

        public void CreateArticle()
        {

        }

        public void UpdateUser()
        {

        }

        public void UpdateUserFaceInfo()
        {

        }

        public void UpdateArticle()
        {

        }

        public void DeleteUser()
        {

        }

        public void DeleteUserFaceInfo()
        {

        }

        public void DeleteArticle()
        {

        }

        public void GetArticles()
        {

        }

        public void GetUserByUsername()
        {

        }

        public void GetUserFaceInfo()
        {

        }


        
    }
}
