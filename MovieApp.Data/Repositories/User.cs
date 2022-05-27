using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MovieApp.Data.DataConnection;
using MovieApp.Entity;
using System.Linq; //
// Linq: Objects, XML, DataTable
namespace MovieApp.Data.Repositories
{
    public class User : IUser
    {
        MovieDbContext _movieDbContext;
        public User(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }
        public string Delete(int userId)
        {
            var user = _movieDbContext.userModel.Find(userId);
            if (user == null)
                return "";
            //_movieDbContext.userModel.Remove(user);
            _movieDbContext.Entry(user).State = EntityState.Deleted;
            _movieDbContext.SaveChanges();
            return "Deleted";
        }

        public UserModel Login(UserModel userModel)
        {
            UserModel userData = null;
            var user =_movieDbContext.userModel.Where(u=>u.Email == userModel.Email && u.Password==userModel.Password).ToList();
            if (user.Count > 0)
                userData = user[0];
            return userData;
        }

        public string Register(UserModel userModel)
        {
            string msg = "";
            _movieDbContext.userModel.Add(userModel);
            _movieDbContext.SaveChanges(); 
            msg = "Inserted";
            return msg;
        }

        public object SelectUserById(int userId)
        {
            var user = _movieDbContext.userModel.Find(userId);
            if (user == null)
                return "";
            return user;
        }

        public object SelectUsers()
        {
             //select * from userModel
            List<UserModel> userList = _movieDbContext.userModel.ToList();
            return userList;
        }

        public string Update(UserModel userModel)
        {
            _movieDbContext.Entry(userModel).State = EntityState.Modified;
            _movieDbContext.SaveChanges();
            return "Updated";
        }
    }
}
