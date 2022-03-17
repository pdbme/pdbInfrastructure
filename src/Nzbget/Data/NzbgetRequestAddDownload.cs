using System.Text.Json.Serialization;

namespace pdbme.pdbInfrastructure.Nzbget.Data;

public class NzbgetRequestAddDownload
{
    [JsonPropertyName("method")]
    public string Method { get; set; } = "";

    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("params")]
    public object[]? Params { get; set; }
}
