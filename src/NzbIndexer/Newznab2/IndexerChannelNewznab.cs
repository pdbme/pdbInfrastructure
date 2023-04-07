using System.Text.Json.Serialization;

namespace pdbme.pdbInfrastructure.NzbIndexer.Newznab2;

public class IndexerChannelNewznab
{
    [JsonPropertyName("item")]
    public List<IndexerItemNewnab2>? Items { get; set; }
}
