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
            if (fileContext.Users.FirstOrDefault(u => u.Username.Equals(user.Username)) == null)
            {
                fileContext.Users.Add(user);
                fileContext.SaveChanges();
            }
            else
            {
                throw new Exception("Username is already taken!");
            }
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