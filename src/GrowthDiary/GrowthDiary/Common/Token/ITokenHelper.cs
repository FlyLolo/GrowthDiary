using GrowthDiary.Model;
using System.Security.Claims;

namespace FlyLolo.JWT
{
    public interface ITokenHelper
    {
        ComplexToken CreateToken(UserViewModel user);
        //ComplexToken CreateToken(Claim[] claims);
        Token RefreshToken(ClaimsPrincipal claimsPrincipal);

    }
}
