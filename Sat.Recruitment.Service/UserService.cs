using Sat.Recruitment.Entity.Commons;
using Sat.Recruitment.Entity.Entities;
using Sat.Recruitment.Entity.Interfaces.Repositories;
using Sat.Recruitment.Entity.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sat.Recruitment.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Result Create(User user)
        {
            var isDuplicated = IsDuplicated(user);
            if (isDuplicated) return new Result("User is duplicated", false);

            user.CalculateGif();
            _userRepository.Create(user);

            return new Result("User Created", true);
        }

        public async Task<IEnumerable<User>>GetList()
        {
            return await _userRepository.GetAll();
        }

        private bool IsDuplicated(User user)
        {
            var _users = GetList().Result;

            return _users.Any(u => u.Address == user.Address
                                || u.Email == user.Email
                                || u.Name == user.Name
                                || u.Phone == user.Phone);
        }

        
    }
}
