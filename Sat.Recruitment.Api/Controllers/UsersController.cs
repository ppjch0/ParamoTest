using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Api.Mappers;
using Sat.Recruitment.Entity.Commons;
using Sat.Recruitment.Entity.Entities;
using Sat.Recruitment.Entity.Interfaces.Services;
using System.Linq;

namespace Sat.Recruitment.Api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public partial class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUserMapper _userMapper;
        public UsersController(IUserService userService, IUserMapper userMapper)
        {
            this._userService = userService;
            this._userMapper = userMapper;
        }

        [HttpPost]
        public ActionResult<Result> CreateUser([FromBody] UserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join(" | ", ModelState.Values
                                                .SelectMany(v => v.Errors)
                                                .Select(e => e.ErrorMessage));
                return new Result(errors, false);
            }

            var user = this._userMapper.MapUserDtoToUser(userDTO);
            var result = this._userService.Create(user);

            return result;
        }
    }
    
}
