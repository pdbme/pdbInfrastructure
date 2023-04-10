namespace pdbme.pdbInfrastructure.Helpers.Interfaces;

public interface IOpenSubtitlesHash
{
    public string ComputeHash(string filepath);
}