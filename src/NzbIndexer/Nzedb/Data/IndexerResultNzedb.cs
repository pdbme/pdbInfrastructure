using System.Text.Json.Serialization;

namespace pdbme.pdbInfrastructure.NzbIndexer.Nzedb.Data;

public class IndexerResultNzedb
{
    [JsonPropertyName("channel")]
    public IndexerChannelNzedb? Channel { get; set; }
}