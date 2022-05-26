using System.Text.Json.Serialization;

using Microsoft.AspNetCore.Mvc;

namespace recipe_service.Models;

public class UserModel
{
    [JsonPropertyName("user")]
    public string? UserName { get; set; }

    [JsonPropertyName("pw")]
    public string? PassWord { get; set; }
}