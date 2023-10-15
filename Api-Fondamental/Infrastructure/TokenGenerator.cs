using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BusinessLogicLayer.Models;
using Microsoft.IdentityModel.Tokens;

namespace Api_Fondamental.Infrastructure
{
    public class TokenGenerator
    {
        public static string secretKey = "µpiçaezjrkuyjfgk:ghmkjghmiugl:hjfvtFSDMOifnZAE MOVjkµ$)'éàipornjfd ù)'$piç";

        public string GenerateToken(UserModel u)
        {
            //Générer la clé de signature du token

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            //Création du payload (Donnée contenues dans le token)

            Claim[] userInfo = new[]
            {
                new Claim(ClaimTypes.Role,
                        (u.RoleId == 3 ? "Admin" : u.RoleId == 2 ? "Modo" : "User")),
                new Claim(ClaimTypes.Sid, u.Id.ToString()),
                new Claim(ClaimTypes.Email, u.Email)
            };

            JwtSecurityToken jwt = new JwtSecurityToken(
                claims: userInfo,
                signingCredentials: credentials,
                expires: DateTime.Now.AddDays(1)
                );

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(jwt);
        }

        //internal static string secretKey = "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJFbWFpbCI6InZlckBtaWMiLCJQYXNzd29yZCI6InRlc3QxMjM0IiwiQWRtaW4iOnRydWUsIlBhcnRpY2lwYW50Ijp0cnVlfQ.zs2jkAXY9gPlmG-TArLmeKGc7gpiXgQ36fKQHDv7CJwSV0OULcuebn2skezd0NnfwprP-_G84QmBqH8If0Nw1Q";
        //public static string myIssuer = "monSiteApi.com";
        //public static string myAudience = "monSite.com";

        //public string GenerateJWT(dynamic user)
        //{
        //    if (user.Email is null)
        //        throw new ArgumentNullException();

        //    //Création des crédentials
        //    SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        //    SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

        //    //Création de l'objet contenant les informations à stocker dans le token
        //    Claim[] myClaims = new[]
        //    {
        //        new Claim(ClaimTypes.Sid, user.Id.ToString()),
        //        new Claim(ClaimTypes.GivenName, $"{user.LastName} {user.FirstName}"),
        //        new Claim(ClaimTypes.Email, user.Email),
        //        new Claim("Participant", user.Participant.ToString()),
        //        new Claim("IsAdmin", user.IsAdmin.ToString()),
        //        new Claim(ClaimTypes.Role, user.GetType().Name)
        //    };

        //    //Génération du token => Nuget : System.IdentityModel.Tokens.Jwt
        //    JwtSecurityToken token = new JwtSecurityToken(
        //        claims: myClaims,
        //        expires: DateTime.Now.AddDays(1),
        //        signingCredentials: credentials,
        //        issuer: myIssuer,
        //        audience: myAudience
        //        );

        //    JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        //    return tokenHandler.WriteToken(token);
    }
    
}
