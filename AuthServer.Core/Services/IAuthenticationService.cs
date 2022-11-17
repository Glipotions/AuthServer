using AuthServer.Common.Dtos;
using AuthServer.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Core.Services
{
    public interface IAuthenticationService
    {

        Task<Response<TokenDto>> CreateToken(LoginDto loginDto);
        Task<Response<TokenDto>> CreateTokenByRefreshToken(string refreshToken);
        /// <summary>
        /// Refresh token çalınma ihtimaline karşı refresh token'ı silme görevi görür.
        /// Çünkü refresh token'in ele geçirilmesi yeni tokenleri elde etmek anlamına gelir
        Task<Response<NoDataDto>> RevokeRefreshToken(string refreshToken);
        Task<Response<ClientTokenDto>> CreateTokenByClient(ClientTokenDto clientTokenDto);
    }
}
