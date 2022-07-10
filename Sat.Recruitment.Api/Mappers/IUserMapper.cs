using Sat.Recruitment.Entity.Entities;

namespace Sat.Recruitment.Api.Mappers
{
    public interface IUserMapper
    {
        User MapUserDtoToUser(UserDTO userDTO);
    }
}