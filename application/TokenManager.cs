
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

using Microsoft.Extensions.Configuration;
using recipe_service.Application.DTOs;

namespace recipe_service.Application;

internal class TokenManager
{
    private IConfiguration _configuration;

    public TokenManager(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string? GenerateToken(UserModel? user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));    
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);    
    
        var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],    
                                         _configuration["Jwt:Issuer"],    
                                         null,    
                                         expires: DateTime.Now.AddMinutes(120),    
                                         signingCredentials: credentials);
    
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}