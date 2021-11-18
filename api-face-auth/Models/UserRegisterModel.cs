using System.Collections.Generic;

namespace api_face_auth.Models
{
    public class UserRegisterModel
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public List<string> imagesBase64 { get; set; }
    }
}