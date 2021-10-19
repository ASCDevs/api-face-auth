using System;

namespace api_face_auth.DataSqlite.Entities
{
    public class User{
        public int id {get;set;}
        public string nome {get;set;}
        public string usuario {get;set;}
        public string senha {get;set;}
        public string email {get;set;}
        public DateTime dataCadastro {get;set;}
    }
}