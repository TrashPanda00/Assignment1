using System.Threading.Tasks;
using Assignment1.Model;

namespace Assignment1.Data
{
    public interface IUserData
    {
        public Task<User> CheckUser(string Username, string Password);

        public Task AddUser(User user);

        public void checkUsername(User newUser);
    }
}