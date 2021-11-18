using System;
using System.ComponentModel.DataAnnotations;

namespace api_face_auth.DataSqlite.Entities
{
    public class User{

        [Key]
        public int idUser {get;set;}
        public string name {get;set;}
        public string surname {get;set;}
        public string username {get;set;}
        public string password { get; set; }
        public string email {get;set;}
        public DateTime registerDate {get;set;}
    }
}