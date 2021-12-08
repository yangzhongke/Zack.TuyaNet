using System.Text.Json.Serialization;

namespace Zack.TuyaNet;
public class TuyaToken
{
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; }

    [JsonPropertyName("expire_time")]
    public int ExpireTime { get; set; }

    [JsonPropertyName("refresh_token")]
    public string RefreshToken { get; set; }

    [JsonPropertyName("uid")]
    public string Uid { get; set; }
}