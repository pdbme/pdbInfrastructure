using System.Text.Json.Serialization;

namespace pdbme.pdbInfrastructure.NzbIndexer.Newznab.Data;

public class IndexerResultNewznabWithChannel
{
    [JsonPropertyName("channel")]
    public IndexerResultNewznab? Channel { get; set; }
}
