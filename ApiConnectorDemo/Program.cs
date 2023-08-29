using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMicrosoftIdentityWebAppAuthentication(builder.Configuration);

builder.Services.AddScoped<IClaimsTransformation, RoleClaimsTransformation>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy =>
       policy.RequireClaim("extension_Roles", new string[] { "Admin" }));
});

builder.Services.AddControllersWithViews(options =>
{
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
    options.Filters.Add(new AuthorizeFilter(policy));
});
builder.Services.AddRazorPages()
    .AddMicrosoftIdentityUI();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();


public class RoleClaimsTransformation : IClaimsTransformation
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

        identity.AddClaims(values.Select(s => new Claim(ClaimTypes.Role, s)));

        return Task.FromResult(principal);
    }
}

