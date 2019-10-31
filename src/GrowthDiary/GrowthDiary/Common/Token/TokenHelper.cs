using GrowthDiary.Model;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace FlyLolo.JWT
{
    public enum TokenType
    {
        AccessToken = 1,
        RefreshToken = 2
    }
    public class TokenHelper : ITokenHelper
    {
        private readonly IOptions<JWTConfig> _options;
        public TokenHelper(IOptions<JWTConfig> options)
        {
            _options = options;
        }

        public Token CreateAccessToken(UserViewModel user)
        {
            Claim[] claims = { new Claim(ClaimTypes.NameIdentifier, user.UserCode), new Claim(ClaimTypes.Name, user.UserName) };

            return CreateToken(claims, TokenType.AccessToken);
        }

        public ComplexToken CreateToken(UserViewModel user)
        {
            Claim[] claims = { new Claim(ClaimTypes.NameIdentifier, user.UserCode), new Claim(ClaimTypes.Name, user.UserName) };

            return new ComplexToken { AccessToken = CreateToken(claims, TokenType.AccessToken),
                RefreshToken = CreateToken(claims, TokenType.RefreshToken),
                User = user
            };
        }

        /// <summary>
        /// 用于创建AccessToken和RefreshToken。
        /// 这里AccessToken和RefreshToken只是过期时间不同，【实际项目】中二者的claims内容可能会不同。
        /// 因为RefreshToken只是用于刷新AccessToken，其内容可以简单一些。
        /// 而AccessToken可能会附加一些其他的Claim。
        /// </summary>
        /// <param name="claims"></param>
        /// <param name="tokenType"></param>
        /// <returns></returns>
        private Token CreateToken(Claim[] claims, TokenType tokenType)
        {
            claims = claims.Append(new Claim("TokenType", tokenType.ToString())).ToArray();
            var now = DateTime.Now;
            var expires = now.Add(TimeSpan.FromMinutes(tokenType.Equals(TokenType.AccessToken) ? _options.Value.AccessTokenExpiresMinutes : _options.Value.RefreshTokenExpiresMinutes));
            var token = new JwtSecurityToken(
                issuer: _options.Value.Issuer,
                audience: _options.Value.Audience,
                claims: claims,
                notBefore: now,
                expires: expires,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Value.IssuerSigningKey)), SecurityAlgorithms.HmacSha256));
            return new Token { TokenContent = new JwtSecurityTokenHandler().WriteToken(token), Expires = expires };
        }

        public Token RefreshToken(ClaimsPrincipal claimsPrincipal)
        {
            if (claimsPrincipal.Claims.Any(m=>m.Type.Equals("TokenType") && m.Value.Equals(TokenType.RefreshToken.ToString())))
            {
                var code = claimsPrincipal.Claims.FirstOrDefault(m => m.Type.Equals(ClaimTypes.NameIdentifier));
                var name = claimsPrincipal.Claims.FirstOrDefault(m => m.Type.Equals(ClaimTypes.Name));
                if (null != code)
                {
                    return CreateAccessToken(new UserViewModel { UserCode = code.Value, UserName = name.Value });
                }
            }

            return null;
        }
    }
}
