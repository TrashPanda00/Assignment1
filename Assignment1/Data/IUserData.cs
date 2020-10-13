using Assignment1.Model;

namespace Assignment1.Data
{
    public interface IUserData
    {
        public User CheckUser(string Username, string Password);

        public void AddUser(User user);
    }
}