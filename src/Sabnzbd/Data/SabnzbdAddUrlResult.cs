namespace pdbme.pdbInfrastructure.Sabnzbd.Data;

public class SabnzbdAddUrlResult
{
    public bool Status { get; set; }
    public List<string> Nzo_ids { get; set; } = new List<string>();
}
