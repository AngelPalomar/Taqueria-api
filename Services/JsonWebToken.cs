using System.Security.Claims;
using Taqueria.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Taqueria.Services
{
    public class JsonWebToken : IJsonWebToken
    {
        private readonly IConfiguration config;
        public JsonWebToken(IConfiguration config)
        {
            this.config = config;
        }

        public string GenerarToken(Usuario usuario)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, usuario.Correo),
                new Claim(JwtRegisteredClaimNames.GivenName, usuario.Nombres),
                new Claim(JwtRegisteredClaimNames.FamilyName, usuario.Apellidos),
                new Claim(JwtRegisteredClaimNames.Gender, usuario.Sexo)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Token:Key"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds,
                Issuer = config["Token:Issuer"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
