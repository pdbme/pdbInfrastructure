using System.Text.Json.Serialization;

namespace pdbme.pdbInfrastructure.Sabnzbd.Data;

public class SabnzbdAddDownloadResult
{
    [JsonPropertyName("status")]
    public bool Status { get; set; }
    public string Error { get; set; } = "";
}
