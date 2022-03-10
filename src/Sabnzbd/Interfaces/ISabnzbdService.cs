﻿using Microsoft.Extensions.Options;
using pdbme.pdbInfrastructure.Sabnzbd.Data;
using pdbme.pdbInfrastructure.Sabnzbd.Services;

namespace pdbme.pdbInfrastructure.Sabnzbd.Interfaces
{
    public interface ISabnzbdService
    {
        void setOptions(IOptions<SabnzbdServiceOptions> optionsToSet);
        bool CheckConnection();
        string GetVersion();
        bool AddDownload(string url);
        SabnzbdQueue? GetQueue(int start, int limit);
        SabnzbdHistory? GetHistory(int start, int limit);
    }
}