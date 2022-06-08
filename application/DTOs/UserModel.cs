using System.Text.Json.Serialization;

namespace recipe_service.Application.DTOs;

public class UserModel
{
    [JsonPropertyName("user")]
    public string? UserName { get; set; }

    [JsonPropertyName("pw")]
    public string? PassWord { get; set; }
}