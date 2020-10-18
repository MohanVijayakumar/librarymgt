using System.Threading.Tasks;
using System.Security.Claims;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

using lmgtusecase.User;
using lmgtdomain.User.Dto;
namespace lmgtweb.Controllers
{
    public class UserCredentialController : ControllerBase
    {
        public UserCredentialController(CredentialValidator credentialValidator)
        {
            _CredentialValidator = credentialValidator;
        }

        private readonly CredentialValidator _CredentialValidator;

        [Route("Credential/Validate")]
        [HttpPost]
        public async Task<IActionResult> Validate(string userName,string password)
        {
            var res = await _CredentialValidator.ValidateAsync(userName,password);            
            if(!res)
            {
                return Ok(new {InvalidCredentials = true});
            }

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(_GenerateClaimsIdentity(_CredentialValidator.User)),
            new AuthenticationProperties()
            );

            return Ok(new {Success = true});
            
        }

        private ClaimsIdentity _GenerateClaimsIdentity(UserDto user)
        {
            return new ClaimsIdentity(_GenerateClaims(user),CookieAuthenticationDefaults.AuthenticationScheme);
        }
        private List<Claim> _GenerateClaims(UserDto user)
        {
            List<Claim> res = new List<Claim>();
            res.Add(new Claim("u_id",user.ID.ToString()));
            res.Add(new Claim(ClaimTypes.Role,user.RoleID.ToString()));

            return res;

        }
    }
}