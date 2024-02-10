using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.Config;
using Application.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace API.Controller.v1;

public class TokenController : BaseController
{
    private readonly JwtConfig _jwtConfig;


    public TokenController(IOptions<JwtConfig> jwtConfig)
    {
        _jwtConfig = jwtConfig.Value;
    }

    [AllowAnonymous]
    [HttpPost]
    public IActionResult Login(LoginDto login)
    {
        if (login.User == "admin" && login.Pass == "admin")
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, login.User),
                new Claim(ClaimTypes.Role, "Admin") // Adicione as roles apropriadas
            };
            
            var token = new JwtSecurityToken
            (
                issuer: _jwtConfig.Autenticador,
                audience: _jwtConfig.Aplicativo,
                claims: claims,
                expires: DateTime.Now.AddHours(_jwtConfig.ValidadeTokenHoras),
                notBefore: DateTime.Now,
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.ChaveSecreta)),
                    SecurityAlgorithms.HmacSha256)
            );
            
           

           
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo.ToLocalTime()
            });
        }

        return Unauthorized("Usuario ou Senha estão invalidos");
    }
}