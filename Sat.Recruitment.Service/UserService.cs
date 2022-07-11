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
        public async Task<Result> Create(User user)
        {
            var isDuplicated = await IsDuplicated(user);
            if (isDuplicated) return new Result("User is duplicated", false);

            user.CalculateGif();
            _userRepository.Create(user);

            return new Result("User Created", true);
        }

        private async Task<bool> IsDuplicated(User user)
        {
            var _users = await _userRepository.GetAll();

            return _users.Any(u => u.Address.ToLower().Trim() == user.Address.ToLower().Trim()
                                || u.Email.ToLower().Trim() == user.Email.ToLower().Trim()
                                || u.Name.ToLower().Trim() == user.Name.ToLower().Trim()
                                || u.Phone.ToLower().Trim() == user.Phone.ToLower().Trim());
        }

        
    }
}
