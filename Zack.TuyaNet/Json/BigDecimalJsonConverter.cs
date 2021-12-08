using System.Text.Json;
using System.Text.Json.Serialization;

namespace Zack.TuyaNet.Json
{
    public class BigDecimalJsonConverter : JsonConverter<double>
    {
        //Convert BigDecimal("temperature": {"Value": "11.00"}) to double
        public override double Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using (var jsonDoc = JsonDocument.ParseValue(ref reader))
            {
                string value = jsonDoc.RootElement.GetProperty("Value").GetString();
                return Convert.ToDouble(value);
            }
        }

        public override void Write(Utf8JsonWriter writer, double value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
