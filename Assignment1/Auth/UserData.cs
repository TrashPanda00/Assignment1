using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Assignment1.Data;
using Assignment1.Model;
using FileData;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Assignment1.Auth
{
    public class UserData : IUserData
    {
        private const string uri = "http://localhost:5000";


        public UserData()
        {
        }

        public async Task AddUser(User newUser)
        {
            IList<User> users = await getUsers();
            User first = users.FirstOrDefault(user => user.Username.Equals(newUser.Username));
            if (first != null)
            {
                await Task.Run (() => throw new Exception("Username is already taken!"));
            }
            else
            {
                Console.WriteLine("i got here");
                HttpClient client = new HttpClient();
                string userAsJson = JsonSerializer.Serialize(newUser);
                HttpContent content = new StringContent(
                    userAsJson,
                    Encoding.UTF8,
                    "application/json");
                await client.PostAsync(uri + "/user", content);
            }
        }

        public void checkUsername(User newUser)
        {
            IList<User> users = getUsers().Result;
            User first = users.FirstOrDefault(user => user.Username.Equals(newUser.Username));
            if (first != null)
            {
                throw new Exception("Username is already taken!");
            }
        }

        public async Task<User> CheckUser(string Username, string Password)
        {
            IList<User> users = await getUsers();
            User first = users.FirstOrDefault(user => user.Username.Equals(Username));
            if (first == null)
                throw new Exception("User not found");
            if (!Password.Equals(first.Password))
                throw new Exception("Incorrect Password");
            return first;
        }

        public async Task<IList<User>> getUsers()
        {
            IList<User> result;

            using (var client = new System.Net.Http.HttpClient())
            {
                client.BaseAddress = new Uri(uri + "/user");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add
                    (new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(uri + "/user").Result;
                var data = response.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<IList<User>>(data);
            }

            return result;
        }
    }
}