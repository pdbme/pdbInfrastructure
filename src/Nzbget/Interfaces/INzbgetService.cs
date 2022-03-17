using Microsoft.Extensions.Options;
using pdbme.pdbInfrastructure.Nzbget.Data;
using pdbme.pdbInfrastructure.Nzbget.Services;

namespace pdbme.pdbInfrastructure.Nzbget.Interfaces
{
    public interface INzbgetService
    {
        void setOptions(IOptions<NzbgetServiceOptions> optionsToSet);
        void CheckConnection();
        int GetVersion();
        List<NzbgetQueue> GetQueue();
        List<NzbgetHistory> GetHistory();
        bool AddDownload(string url);
    }
}