using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;
namespace lmgtweb
{
    public class UtilitiesClaims
    {
        public static int GetUserID(List<Claim> claims )
        {
            return int.Parse(claims.Single(s=> s.Type == "u_id").Value);
        }

        public static short GetRoleID(List<Claim> claims)
        {
            return short.Parse(claims.Single(s=> s.Type == ClaimTypes.Role).Value);
        }
    }
}