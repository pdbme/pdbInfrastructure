using System.Text.Json.Serialization;

namespace pdbme.pdbInfrastructure.NzbIndexer.Nzedb.Data;

public class IndexerRowNzedb
{
    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("link")]
    public string DownloadLink { get; set; } = string.Empty;

    [JsonPropertyName("attr")]
    public List<IndexerItemAttributeNzedb>? Attributes { get; set; }

    [JsonPropertyName("pubDate")]
    public DateTime Created { get; set; }
}
