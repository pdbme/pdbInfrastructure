using System.Text.Json.Serialization;

namespace pdbme.pdbInfrastructure.NzbIndexer.Nzedb.Data;

public class IndexerChannelNzedb
{
    [JsonPropertyName("item")]
    public List<IndexerRowNzedb>? Rows { get; set; }
}
