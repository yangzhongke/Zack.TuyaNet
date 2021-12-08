using System.Security.Cryptography;
using System.Text;

namespace Zack.TuyaNet
{
    class HashHelper
    {
        public static string ComputeSHA256(string s)
        {
            using var sha256 = SHA256.Create();
            return string.Concat(sha256.ComputeHash(Encoding.UTF8.GetBytes(s))
                .Select(b => $"{b:x2}"));
        }

        public static string ComputeHMACSHA256(string secret,string s)
        {
            using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secret));
            return string.Concat(hmac.ComputeHash(Encoding.UTF8.GetBytes(s))
                .Select(b => $"{b:X2}"));
        }
    }
}
