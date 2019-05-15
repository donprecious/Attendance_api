using AttendanceApi.Providers;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using AttendanceApi.Repositories;
using Microsoft.AspNetCore.Identity;
using AttendanceApi.Data;
using AttendanceApi.Models;
namespace AttendanceApi.Factories
{
    public class JwtFactory : IJwtFactory
    {
        private readonly JwtIssuerOptions _jwtOptions;
        private UserManager<ApplicationUser> _userManager;
        public JwtFactory(IOptions<JwtIssuerOptions> jwtOptions, UserManager<ApplicationUser> userManager)
        {
            _jwtOptions = jwtOptions.Value;
            _userManager = userManager;
            ThrowIfInvalidOptions(_jwtOptions);
           
        }

        public async Task<string> GenerateEncodedToken(string userName, ClaimsIdentity identity)
        {
          
            var claims = new[]
              {
                 new Claim(JwtRegisteredClaimNames.Sub, userName),
                 new Claim(JwtRegisteredClaimNames.Jti, await _jwtOptions.JtiGenerator()),
                 new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(_jwtOptions.IssuedAt).ToString(), ClaimValueTypes.Integer64),
                 identity.FindFirst(Helpers.Constants.Strings.JwtClaimIdentifiers.Rol),
                 identity.FindFirst(Helpers.Constants.Strings.JwtClaimIdentifiers.Id)
             };

            // Create the JWT security token and encode it.
            var user = await _userManager.FindByNameAsync(userName);
             var roles = await _userManager.GetRolesAsync(user);
          
            var jwt = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: claims,
                notBefore: _jwtOptions.NotBefore,
                expires: _jwtOptions.Expiration,
                signingCredentials: _jwtOptions.SigningCredentials
                );
            jwt.Payload.Add("roles", roles);

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;
        }

        public async Task<ClaimsIdentity> GenerateClaimsIdentity(string userName, string id)
        {
           
           var claimsIdentity = new ClaimsIdentity(new GenericIdentity(userName, "Token"), new[]
            {
                new Claim(Helpers.Constants.Strings.JwtClaimIdentifiers.Id, id),
                new Claim(Helpers.Constants.Strings.JwtClaimIdentifiers.Rol, Helpers.Constants.Strings.JwtClaims.ApiAccess), 
               
            });

            var user = await _userManager.FindByIdAsync(id);
            
            var roles = await _userManager.GetRolesAsync(user);
           
            if (roles !=null)
            {
               //var roles = rolesTask.Result;
               // var roles = _role.UserRoles.(id).Result;
                if (roles.Count() != 0)
                {
                    //  claimsIdentity.AddClaim(new Claim("Role", ""));
                    foreach (var i in roles)
                    {

                        claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, i));
                    }
                  
                }
                
               

            }

            return claimsIdentity;
        }
    
        /// <returns>Date converted to seconds since Unix epoch (Jan 1, 1970, midnight UTC).</returns>
        private static long ToUnixEpochDate(DateTime date)
          => (long)Math.Round((date.ToUniversalTime() -
                               new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero))
                              .TotalSeconds);

        private static void ThrowIfInvalidOptions(JwtIssuerOptions options)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));

            if (options.ValidFor <= TimeSpan.Zero)
            {
                throw new ArgumentException("Must be a non-zero TimeSpan.", nameof(JwtIssuerOptions.ValidFor));
            }

            if (options.SigningCredentials == null)
            {
                throw new ArgumentNullException(nameof(JwtIssuerOptions.SigningCredentials));
            }

            if (options.JtiGenerator == null)
            {
                throw new ArgumentNullException(nameof(JwtIssuerOptions.JtiGenerator));
            }
        }

      
    }
}
