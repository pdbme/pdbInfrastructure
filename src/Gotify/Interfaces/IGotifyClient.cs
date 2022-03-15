namespace pdbme.pdbInfrastructure.Gotify.Interfaces;

public interface IGotifyClient
{
    void SendMessage(string title, string message, int priority);
}
