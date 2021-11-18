using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_face_auth.Models
{
    public class FaceModel
    {
        public string idUser { get; set; }
        public DateTime createdDate { get; set; }
        public Byte[] imageBytes { get; set; }
    }
}
