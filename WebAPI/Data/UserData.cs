using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model;

namespace WebAPI.Data
{
    public class UserData : IUserData
    {
        private CustomDBContext DBContext;


        public UserData()
        {
            DBContext = new CustomDBContext();
        }
        public async Task AddUser(User user)
        {
            Console.WriteLine(user.Username);
            if (DBContext.Users.FirstOrDefault(u => u.Username.Equals(user.Username)) == null)
            {
                DBContext.Users.AddAsync(user);
                DBContext.SaveChangesAsync();
            }
        }

        public async Task<IList<User>> getUsers()
        {
            IList<User> users = DBContext.Users.ToList();
            return users;
        }
    }
}