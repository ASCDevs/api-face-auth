using api_face_auth.DataSqlite.Entities;
using api_face_auth.DataSqlite.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_face_auth.DataSqlite.Manager
{
    public class ContextManager
    {
        private ContextStore _store;
        public ContextManager(ContextStore store)
        {
            _store = store;
        }

        public int CreateUser(User newUser)
        {
            return _store.CreateUser(newUser);
        }

        public void CreateUserFaceInfo(UserFace newFaceInfo)
        {
            _store.CreateUser(newFaceInfo);
        }
    }
}
