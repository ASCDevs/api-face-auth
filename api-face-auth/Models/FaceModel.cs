using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_face_auth.Models
{
    public class FaceModel
    {
        public int id { get; set; }
        public DateTime dtCreated { get; set; }
        public Byte[] imagem { get; set; }
    }
}
