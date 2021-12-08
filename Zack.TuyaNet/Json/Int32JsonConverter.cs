using System.Text.Json;
using System.Text.Json.Serialization;

namespace Zack.TuyaNet.Json
{
    public class Int32JsonConverter : JsonConverter<int>
    {
        public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var s = reader.GetString();
            return Convert.ToInt32(s);
        }

        public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
