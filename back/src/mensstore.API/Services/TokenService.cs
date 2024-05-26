using mensstore.Core;
using mensstore.Core.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace mensstore.API;
// 
public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;
    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken(Usuario usuario)
    {
        string SecurityKey = _configuration.GetSection("Jwt:Key").Value;

        var Key = Encoding.ASCII.GetBytes(SecurityKey);

        var TokenDescriptor = new SecurityTokenDescriptor
        {
            // Usar refresh tokens quando expirar e o usuário logar novamente
            Expires = DateTime.UtcNow.AddHours(8),

            // Credenciais usadas para encriptar e desencriptar o token
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Key), SecurityAlgorithms.HmacSha256Signature),

            // É nas Claims que configuramos quais informações serão transmitidas no payload do token
            // Nesse caso será apenas o nome do usuário
            Subject = new System.Security.Claims.ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, usuario.Name)
            })
        };

        var TokenHandler = new JwtSecurityTokenHandler();
        return TokenHandler.WriteToken(TokenHandler.CreateToken(TokenDescriptor));
    }
}
