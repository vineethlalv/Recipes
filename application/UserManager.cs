using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

using recipe_service.Application.Constants;
using recipe_service.Application.Interfaces;
using recipe_service.Application.DTOs;


namespace recipe_service.Application;

public class UserManager : IUserManager
{
    private IConfiguration _configuration;
    private IDataAccess _dataAccess;

    public UserManager(IConfiguration configuration, IDataAccess dataAccess)
    {
        _configuration = configuration;
        _dataAccess = dataAccess;
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

    public UserStatus AddUser(UserModel userDetails)
    {
        if(userDetails.UserName is null || userDetails.PassWord is null)
            return UserStatus.InvalidInputs;

        if(_dataAccess.IsUserExists(userDetails.UserName))
            return UserStatus.UserNameExists;
        // @TODO: check password match policy
        else
        {
            _dataAccess.AddUser(userDetails);
            return UserStatus.Ok;
        }
    }
}