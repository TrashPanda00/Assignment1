using System;
using System.Collections.Generic;
using System.Linq;
using Assignment1.Data;
using Assignment1.Model;

namespace Assignment1.Auth
{
    public class UserData : IUserData
    {
        private List<User> Users;

        public UserData()
        {
            Users = new List<User>()
            {
                new User
                {
                    BirthDate = "10-01-2000",
                    FirstName = "Bogdan",
                    LastName = "Mezei",
                    Password = "Baracuda",
                    Username = "TrashPanda"
                },
                new User
                {
                    BirthDate = "25-10-1997",
                    FirstName = "Jane",
                    LastName = "Doe",
                    Password = "123",
                    Username = "hello"
                }
            }.ToList();

        }

        public User CheckUser(string Username, string Password)
        {
            User first = Users.FirstOrDefault(user => user.Username.Equals(Username));
            if(first == null)
                throw new Exception("User not found");
            if(!Password.Equals(first.Password))
                throw new Exception("Incorrect Password");
            return first;
        }
    }
}