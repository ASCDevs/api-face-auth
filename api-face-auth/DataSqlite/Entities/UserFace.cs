using System;
using System.ComponentModel.DataAnnotations;

namespace api_face_auth.DataSqlite.Entities
{
    public class UserFace{
        [Key]
        public int idface {get;set;}
        public int iduser {get;set;}
        public byte[] image {get;set;}
    }
}