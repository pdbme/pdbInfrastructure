using System.Text.Json.Serialization;

namespace pdbme.pdbInfrastructure.NzbIndexer.Newznab2;

public class IndexerItemNewnab2
{
    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("link")]
    public string DownloadLink { get; set; } = string.Empty;

    [JsonPropertyName("newznab:attr")]
    public List<IndexerItemAttributeNewnab2>? Attributes { get; set; }

    [JsonPropertyName("pubDate")]
    public DateTime Created { get; set; }
}
