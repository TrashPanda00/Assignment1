using System;
using System.Collections.Generic;
using System.Linq;
using Assignment1.Data;
using Assignment1.Model;
using FileData;

namespace Assignment1.Auth
{
    public class UserData : IUserData
    {
        private FileContext fileContext;


        public UserData()
        {
            fileContext = new FileContext();
        }
        public void AddUser(User user)
        {
            fileContext.Users.Add(user);
            fileContext.SaveChanges();
        }

        public User CheckUser(string Username, string Password)
        {
            User first = fileContext.Users.FirstOrDefault(user => user.Username.Equals(Username));
            if(first == null)
                throw new Exception("User not found");
            if(!Password.Equals(first.Password))
                throw new Exception("Incorrect Password");
            return first;
        }
    }
}