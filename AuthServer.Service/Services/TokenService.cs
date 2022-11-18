using AuthServer.Common.Configurations;
using AuthServer.Core.Configuration;
using AuthServer.Core.DTOs;
using AuthServer.Core.Models;
using AuthServer.Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace AuthServer.Service.Services
{
    /// <summary>
    /// 5. Bölüm
    /// </summary>
    internal class TokenService : ITokenService
    {
        private readonly UserManager<UserApp> _userManager;
        private readonly CustomTokenOption _tokenOption;
        public TokenService(UserManager<UserApp> userManager, IOptions<CustomTokenOption> tokenOption)
        {
            _userManager = userManager;
            _tokenOption = tokenOption.Value;
        }

        private string CreateRefreshToken()
        {
            // guid de dönülebilir.

            var numberByte = new Byte[32];
            /// random bir değer üretir. Guid'e göre çok daha unique bir değer oluşturur.
            /// aynı bir değer oluşması imkansıza yakındır
            using var rnd = RandomNumberGenerator.Create();
            rnd.GetBytes(numberByte);
            return Convert.ToBase64String(numberByte);
        }

        private IEnumerable<Claim>GetClaim(UserApp userApp, List<string> audiences)
        {
            /// kullanıcıyla ilgili claimleri barındırır.
            var userList = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userApp.Id),
                new Claim(JwtRegisteredClaimNames.Email, userApp.Email),
                new Claim(ClaimTypes.Name, userApp.UserName),
                /// random bir claim atarak daha da güvenli hale getirmek istendi.
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            userList.AddRange(audiences.Select(x => new Claim(JwtRegisteredClaimNames.Aud, x)));
            
            return userList;
        }

        private IEnumerable<Claim> GetClaimsByClient(Client client)
        {
            var claims = new List<Claim>();
            claims.AddRange(client.Audiences.Select(x => new Claim(JwtRegisteredClaimNames.Aud, x)));

            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString());
            new Claim(JwtRegisteredClaimNames.Sub, client.Id.ToString());

            return claims;
        }

        public TokenDto CreateToken(UserApp userApp)
        {
            throw new NotImplementedException();
        }

        public ClientTokenDto CreateTokenByClient(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
