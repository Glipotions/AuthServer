using AuthServer.Common.Dtos;
using AuthServer.Core.DTOs;

namespace AuthServer.Core.Services
{
    public interface IUserService
    {
        Task<Response<UserAppDto>> CreateUserAsync(CreateUserDto createUserDto);
        Task<Response<UserAppDto>> GetUserByNameAsync(string username);
    }
}
