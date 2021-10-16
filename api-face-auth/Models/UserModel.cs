using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_face_auth.Models
{
    public class UserModel
    {
        public int userId { get; set; }
        public string userName { get; set; }
        public List<FaceModel> userFaceImages { get; set; }
    }
}
