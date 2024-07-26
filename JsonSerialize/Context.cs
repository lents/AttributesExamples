using System.Text.Json.Serialization;
using static JsonSerialize.Program;

namespace JsonSerialize
{
    [JsonSourceGenerationOptions(WriteIndented = false)]
    [JsonSerializable(typeof(Person))]
    [JsonSerializable(typeof(Address))]
    [JsonSerializable(typeof(Company))]
    public partial class MyJsonContext : JsonSerializerContext
    {
    }

}
