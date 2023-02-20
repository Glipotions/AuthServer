using AuthServer.Common.Dtos;
using AuthServer.Core.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AuthServer.Core.Services
{
    public interface IUserService
    {
        Task<Response<UserAppDto>> CreateUserAsync(CreateUserDto createUserDto);
        Task<Response<UserAppDto>> GetUserByNameAsync(string username);

        Task<Response<NoContent>> CreateUserRoles(string userName);
    }
}
