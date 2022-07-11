using Sat.Recruitment.Entity.Entities;
using Sat.Recruitment.Entity.Enums;
using Sat.Recruitment.Entity.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Sat.Recruitment.Repository
{
    public class UserRepository : IUserRepository
    {
        //TODO: Add appsettings configuration 
        private readonly string path = Directory.GetCurrentDirectory() + "/Files/Users.txt";


        public void Create(User user)
        {
            var stringUser = $"{user.Name},{user.Email},{user.Phone},{user.Address},{user.Type},{user.Money}" + Environment.NewLine;

            File.AppendAllText(path, stringUser);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var _users = new List<User>();
            var file = new FileStream(path, FileMode.Open);

            using (StreamReader reader = new StreamReader(file))
            {
                while (reader.Peek() >= 0)
                {
                    var line = await reader.ReadLineAsync();
                    var userLine = line.Split(',');

                    var user = User.GetUser((UserType)Enum.Parse(typeof(UserType), userLine[4].ToString()));

                    user.Name = userLine[0].ToString();
                    user.Email = userLine[1].ToString();
                    user.Phone = userLine[2].ToString();
                    user.Address = userLine[3].ToString();
                    user.Money = decimal.Parse(userLine[5]);

                    _users.Add(user);
                }
            }
                
            return _users;
        }

    }
}
