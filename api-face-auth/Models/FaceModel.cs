using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_face_auth.Models
{
    public class FaceModel
    {
        public string nomeId { get; set; }
        public DateTime dtCriacao { get; set; }
        public string metaDados {get;set;}
        public string extensao {get;set;}
        public Byte[] imagemBytes { get; set; }
    }
}
