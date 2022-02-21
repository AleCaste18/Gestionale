using System.Security.Claims;

namespace Gestionale.Authorization.Claims
{
    public class ClaimsStore
    {
        public static List<Claim> AllClaims = new List<Claim>()
    {
        new Claim("Create Role", "true"),
        new Claim("Edit Role", "true"),
        new Claim("Delete Role", "true")
    };
    }
}
