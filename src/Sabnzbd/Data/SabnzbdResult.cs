namespace pdbme.pdbInfrastructure.Sabnzbd.Data;

public class SabnzbdResult
{
    public string Status { get; set; } = "";
    public string Error { get; set; } = "";
    public string Version { get; set; } = "";
    public SabnzbdHistory History { get; set; } = new SabnzbdHistory();
    public SabnzbdQueue Queue { get; set; } = new SabnzbdQueue();
}
