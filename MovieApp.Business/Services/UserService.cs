using System;
using System.Collections.Generic;
using System.Text;
using MovieApp.Data.Repositories;
using MovieApp.Entity;

namespace MovieApp.Business.Services
{
    public class UserService
    {
        IUser _iuser;
        public UserService(IUser user)
        {
            _iuser = user;
        }
        public string Register(UserModel userModel)
        {
           return _iuser.Register(userModel);
        }
        public object Login(UserModel userModel)
        {
            return _iuser.Login(userModel);
        }
        public object SelectUsers()
        {
          return  _iuser.SelectUsers();
        }
        public object SelectUserById(int userId)
        {
            return _iuser.SelectUserById(userId);
        }
        public string Updateuser(UserModel userModel)
        {
            return _iuser.Update(userModel);
        }
        public string DeleteUser(int userId)
        {
            return _iuser.Delete(userId);
        }
    }
}
