using System.Text.Json.Serialization;

namespace pdbme.pdbInfrastructure.NzbIndexer.Newznab2;

public class IndexerItemAttributeSubNewnab2
{
    [JsonPropertyName("name")]
    public string Key { get; set; } = string.Empty;

    [JsonPropertyName("value")]
    public string Value { get; set; } = string.Empty;
}
