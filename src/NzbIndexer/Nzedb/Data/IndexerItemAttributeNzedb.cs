using System.Text.Json.Serialization;

namespace pdbme.pdbInfrastructure.NzbIndexer.Nzedb.Data;

public class IndexerItemAttributeNzedb
{
    [JsonPropertyName("@attributes")]
    public IndexerItemSubAttributeNzedb? SubAttribute { get; set; }
}
