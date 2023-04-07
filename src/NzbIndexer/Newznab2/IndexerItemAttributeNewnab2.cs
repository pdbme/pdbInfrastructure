using System.Text.Json.Serialization;

namespace pdbme.pdbInfrastructure.NzbIndexer.Newznab2;

public class IndexerItemAttributeNewnab2
{
    [JsonPropertyName("@attributes")]
    public IndexerItemAttributeSubNewnab2? SubAttributes { get; set; }
}
