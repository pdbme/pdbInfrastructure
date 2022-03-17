namespace pdbme.pdbInfrastructure.Nzbget.Data;

public class NzbgetResult<T>
{
    public string Version { get; set; } = "";
    public T? Result { get; set; }
}
