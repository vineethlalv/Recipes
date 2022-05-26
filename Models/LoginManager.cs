using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace recipe_service.Models;

public class LoginManager : ILoginManager
{
    private IConfiguration _configuration;

    public LoginManager(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public UserModel? Authenticate(string? userName, string? passWord)
    {
        // @TODO: slat password compare against db
        UserModel? user = null;

        // @TEMP code - authenticate any for testing
        user = new UserModel{ UserName = "user123" };

        return user;
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