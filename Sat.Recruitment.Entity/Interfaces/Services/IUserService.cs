using Sat.Recruitment.Entity.Commons;
using Sat.Recruitment.Entity.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sat.Recruitment.Entity.Interfaces.Services
{
    public interface IUserService
    {
        Task<Result> Create(User user);
    }
}