using Microsoft.Extensions.Options;
using System.Text.Json;

namespace Zack.TuyaNet;
public class TuyaApiClient
{
    private readonly IHttpClientFactory httpClientFactory;
    private TuyaToken token = null;
    private readonly IOptionsSnapshot<TuyaConfig> tuyaOptions;

    /// <summary>
    /// Creates a new instance of the TuyaApi class.
    /// </summary>
    /// <param name="region">Region of server.</param>
    /// <param name="accessId">Access ID/Client ID from https://iot.tuya.com/ .</param>
    /// <param name="apiSecret">API secret from https://iot.tuya.com/ .</param>
    public TuyaApiClient(IHttpClientFactory httpClientFactory,IOptionsSnapshot<TuyaConfig> tuyaOptions)
    {
        this.httpClientFactory = httpClientFactory;
        this.tuyaOptions = tuyaOptions;
    }
    private static string RegionToHost(Region region)
    {
        string urlHost = null;
        switch (region)
        {
            case Region.China:
                urlHost = "openapi.tuyacn.com";
                break;
            case Region.WesternAmerica:
                urlHost = "openapi.tuyaus.com";
                break;
            case Region.EasternAmerica:
                urlHost = "openapi-ueaz.tuyaus.com";
                break;
            case Region.CentralEurope:
                urlHost = "openapi.tuyaeu.com";
                break;
            case Region.WesternEurope:
                urlHost = "openapi-weaz.tuyaeu.com";
                break;
            case Region.India:
                urlHost = "openapi.tuyain.com";
                break;
        }
        return urlHost;
    }

    public async Task<string> RequestAsync(string uri, HttpMethod httpMethod,
        object? body = null,
        Dictionary<string, string>? headers = null,bool isTokenApi=false)
    {
        var tuyaConfig = tuyaOptions.Value;

        var urlHost = RegionToHost(tuyaConfig.Region);
        var url = new Uri($"https://{urlHost}/{uri}");
        var now = (DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalMilliseconds.ToString("0");
        string headersStr = "";
        if (headers == null)
        {
            headers = new Dictionary<string, string>();
        }
        else
        {
            headersStr = string.Concat(headers.Select(kv => $"{kv.Key}:{kv.Value}\n"));
            headers.Add("Signature-Headers", string.Join(":", headers.Keys));
        }
        string bodyStr = "";
        if (body != null)
        {
            bodyStr = JsonSerializer.Serialize(body,new JsonSerializerOptions { PropertyNamingPolicy= JsonNamingPolicy.CamelCase });
        }
        string payload;
        //https://developer.tuya.com/cn/docs/iot/singnature?id=Ka43a5mtx1gsc
        if (isTokenApi)
        {
            payload = tuyaConfig.AccessId + now;
            headers["secret"] = tuyaConfig.ApiSecret;
        }
        else
        {
            if(token==null)
            {
                throw new Exception("Please call RefreshAccessTokenAsync first!");
            }
            payload = tuyaConfig.AccessId + token.AccessToken + now;
        }
        var content_SHA256 = HashHelper.ComputeSHA256(bodyStr);
        payload += httpMethod + "\n" +
          content_SHA256 + '\n' +
         headersStr + '\n' +
         url.PathAndQuery;

        string signature = HashHelper.ComputeHMACSHA256(tuyaConfig.ApiSecret, payload);
        headers["client_id"] = tuyaConfig.AccessId;
        headers["sign"] = signature;
        headers["t"] = now;
        headers["sign_method"] = "HMAC-SHA256";
        if(!isTokenApi)
        {
            headers["access_token"] = token.AccessToken;
        }
        using var httpRequestMessage = new HttpRequestMessage
        {
            Method = httpMethod,
            RequestUri = url
        };
        foreach (var h in headers)
        { 
            httpRequestMessage.Headers.Add(h.Key, h.Value);
        }
        StringContent? reqBody = null;
        using var httpClient = httpClientFactory.CreateClient();
        if (!string.IsNullOrEmpty(bodyStr))
        {
            reqBody = new StringContent(bodyStr);
            httpRequestMessage.Content = reqBody;
        }
        using var response = await httpClient.SendAsync(httpRequestMessage);
        if(reqBody!=null)
        {
            reqBody.Dispose();
        }
        var responseString = await response.Content.ReadAsStringAsync();
        var root = JsonSerializer.Deserialize<JsonElement>(responseString);
        var success = root.GetProperty("success").GetBoolean();
        if (!success) throw new Exception(responseString);
        var result = root.GetProperty("result").GetRawText();
        return result;
    }

    /// <summary>
    /// Refreshes access token if it's expired or not requested yet.
    /// </summary>
    public async Task RefreshAccessTokenAsync()
    {
        var uri = "v1.0/token?grant_type=1";
        var response = await RequestAsync(uri, HttpMethod.Get, isTokenApi: true);
        this.token = JsonSerializer.Deserialize<TuyaToken>(response);
    }

    /// <summary>
    /// Requests info about device by it's ID.
    /// </summary>
    /// <param name="deviceId">Device ID.</param>
    /// <returns>Device info.</returns>
    public async Task<DeviceInfo> GetDeviceAsync(string deviceId)
    {
        var uri = $"v1.0/devices/{deviceId}";
        var response = await RequestAsync(uri,HttpMethod.Get);
        return JsonSerializer.Deserialize<DeviceInfo>(response);
    }

    public async Task<DeviceInfo[]> ListDevicesAsync(string uid)
    {
        var uri = $"v1.0/users/{uid}/devices";
        var response = await RequestAsync(uri, HttpMethod.Get);
        return JsonSerializer.Deserialize<DeviceInfo[]>(response);
    }

    public async Task<bool> SendCommandAsync(string deviceId,string code,object? value=null)
    {
        var uri = $"v1.0/iot-03/devices/{deviceId}/commands";
        object body;
        if(value==null)
        {
            body = new { commands = new[] { new { Code = code } } };
        }
        else
        {
            body = new { commands = new[] { new { Code = code, Value = value } } };
        }
        var response = await RequestAsync(uri, HttpMethod.Post, body: body);
        return JsonSerializer.Deserialize<bool>(response);
    }

    public async Task<string> ListDeviceFunctionsAsync(string deviceId)
    {
        var uri = $"v1.0/iot-03/devices/{deviceId}/functions";
        var response = await RequestAsync(uri, HttpMethod.Get);
        return response;
    }

    public async Task<DeviceStatus[]> ListDeviceStatusAsync(string deviceId)
    {
        var uri = $"v1.0/iot-03/devices/{deviceId}/status";
        var response = await RequestAsync(uri, HttpMethod.Get);
        return JsonSerializer.Deserialize<DeviceStatus[]>(response);
    }

    public async Task<string> GetHLSStreamUrl(string uid,string deviceId)
    {
        string uri = $"v1.0/users/{uid}/devices/{deviceId}/stream/actions/allocate";
        var response = await RequestAsync(uri, HttpMethod.Post, body:new { type="hls"});
        return response;
    }
}