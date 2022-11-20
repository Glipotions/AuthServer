using AuthServer.Common.Dtos;
using AuthServer.Core.DTOs;

namespace AuthServer.Core.Services
{
    public interface IAuthenticationService
    {

        Task<Response<TokenDto>> CreateTokenAsync(LoginDto loginDto);
        Task<Response<TokenDto>> CreateTokenByRefreshToken(string refreshToken);
        /// <summary>
        /// Refresh token çalınma ihtimaline karşı refresh token'ı silme görevi görür.
        /// Çünkü refresh token'in ele geçirilmesi yeni tokenleri elde etmek anlamına gelir
        Task<Response<NoDataDto>> RevokeRefreshToken(string refreshToken);
        Response<ClientTokenDto> CreateTokenByClient(ClientLoginDto clientTokenDto);
    }
}
