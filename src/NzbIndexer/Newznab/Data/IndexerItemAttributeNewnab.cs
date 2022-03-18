using System.Text.Json.Serialization;

namespace pdbme.pdbInfrastructure.NzbIndexer.Newznab.Data;

public class IndexerItemAttributeNewnab
{
    [JsonPropertyName("_name")]
    public string Key { get; set; } = string.Empty;

    [JsonPropertyName("_value")]
    public string Value { get; set; } = string.Empty;
}
