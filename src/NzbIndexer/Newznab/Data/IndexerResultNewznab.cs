using System.Text.Json.Serialization;

namespace pdbme.pdbInfrastructure.NzbIndexer.Newznab.Data;

public class IndexerResultNewznab
{
    [JsonPropertyName("item")]
    public List<IndexerItemNewnab>? Items { get; set; }
}
