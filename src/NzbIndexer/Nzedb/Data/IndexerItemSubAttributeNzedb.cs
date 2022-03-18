using System.Text.Json.Serialization;

namespace pdbme.pdbInfrastructure.NzbIndexer.Nzedb.Data;

public class IndexerItemSubAttributeNzedb
{
    [JsonPropertyName("name")]
    public string Key { get; set; } = string.Empty;

    public string Value { get; set; } = string.Empty;
}
