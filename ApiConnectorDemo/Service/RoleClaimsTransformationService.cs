using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace ApiConnectorDemo.Service;

public class RoleClaimsTransformationService : IClaimsTransformation
{
    public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
    {
        ClaimsIdentity claimsIdentity = new ClaimsIdentity();

        var identity = principal.Identities.FirstOrDefault();

        if (identity is null)
            return Task.FromResult(principal);

        Claim? extensionRoles = principal.Claims?.FirstOrDefault(x => x.Type == "extension_Roles");

        if (extensionRoles is null)
            return Task.FromResult(principal);

        var values = extensionRoles.Value.Split(',');

        identity.AddClaims(values.Select(role => new Claim(ClaimTypes.Role, role)));

        return Task.FromResult(principal);
    }
}