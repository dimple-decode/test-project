using CRUD_Reponsive_Web_API.Models;
using CRUD_Resonsive_Web_API.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Reponsive_Web_API.Utilities
{
    public class TokenGenerator
    {
        public static UserAuth GenerateUserToken(Account account, List<Claim> claims)
        {
            var userAuth = new UserAuth();

            userAuth.BearerToken = GetToken(account, claims);
            userAuth.Username = account.Username;
            userAuth.Claims = new List<UserClaim>();
            foreach(var claim in claims)
            {
                userAuth.Claims.Add(new UserClaim { ClaimType = claim.Type, ClaimValue = claim.Value });
            }

            return userAuth;
        }

        private static string GetToken(Account account, List<Claim> claims)
        {
            var issuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SomeRandomlyGeneratedStringSomeRandomlyGeneratedString"));
            var cred = new SigningCredentials(issuerSigningKey, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken("Issuer", "Audience", claims, expires: DateTime.UtcNow.AddDays(30), signingCredentials: cred);
            var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenValue;
        }
    }
}
