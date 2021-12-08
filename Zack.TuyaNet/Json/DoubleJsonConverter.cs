using System.Text.Json;
using System.Text.Json.Serialization;

namespace Zack.TuyaNet.Json
{
    public class DoubleJsonConverter : JsonConverter<double>
    {
        public override double Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var s = reader.GetString();
            return Convert.ToDouble(s);
        }

        public override void Write(Utf8JsonWriter writer, double value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
