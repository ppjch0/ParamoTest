using Sat.Recruitment.Entity.Entities;
using Sat.Recruitment.Entity.Enums;
using System;

namespace Sat.Recruitment.Api.Mappers
{
    public class UserMapper : IUserMapper
    {
        public User MapUserDtoToUser(UserDTO userDTO)
        {
            var type = (UserType) Enum.Parse(typeof(UserType), userDTO.UserType);
            var email = NormalizeEmail(userDTO.Email);
            
            var user = User.GetUser(type);
            
            user.Address = userDTO.Address;
            user.Email = email;
            user.Money = userDTO.Money;
            user.Name = userDTO.Name;
            user.Phone = userDTO.Phone;

            return user;
        }

        private string NormalizeEmail(string email)
        {
            //Normalize email
            var aux = email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);

            var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);

            aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);

            return string.Join("@", new string[] { aux[0], aux[1] });
        }
    }
}
