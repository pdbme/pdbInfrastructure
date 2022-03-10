using System;
using System.Net;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using pdbme.pdbInfrastructure.Sabnzbd.Data;
using pdbme.pdbInfrastructure.Sabnzbd.Interfaces;
using RestSharp;
using RestSharp.Serializers.Json;

namespace pdbme.pdbInfrastructure.Sabnzbd.Services
{
    public class SabnzbdService : ISabnzbdService
    {
        private readonly ILogger<ISabnzbdService> logger;
        private SabnzbdServiceOptions options;
        private RestClient client;

        public SabnzbdService(ILogger<ISabnzbdService> logger, IOptions<SabnzbdServiceOptions> options)
        {
            this.logger = logger;
            this.options = options?.Value ?? new SabnzbdServiceOptions();

            if (string.IsNullOrEmpty(this.options.Url))
            {
                client = new RestClient();
            }
            else
            {
                client = new RestClient(this.options.Url);
            }

            client.UseSystemTextJson(new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            });
        }

        public void setOptions(IOptions<SabnzbdServiceOptions> optionsToSet)
        {
            options = optionsToSet.Value;

            if (string.IsNullOrEmpty(options.Url))
            {
                return;
            }

            client = new RestClient(options.Url);
            client.UseSystemTextJson(new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            });
        }

        public bool CheckConnection()
        {
            var version = GetVersion();
            logger.LogInformation($"Connection to {options.Url} was {(string.IsNullOrEmpty(version) ? "not successful" : "successful")} - Version: {version}");
            return !string.IsNullOrEmpty(version);
        }

        public string GetVersion()
        {
            var request = new RestRequest("/", Method.Get);
            request.AddQueryParameter("mode", "version");
            request.AddQueryParameter("output", "json");

            var response = client.ExecuteGetAsync<SabnzbdResult>(request).GetAwaiter().GetResult();
            if (response.IsSuccessful)
            {
                var versionData = response.Data;

                return versionData == null ? "" : versionData.Version;
            }

            var errormessage = "sabnzbd returned " + response.StatusCode.ToString() + " HTTP-Status-Code. " + response.ErrorMessage;
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                errormessage += " Hint: sabnzbd probably needs username and password for authentication.";
            }

            throw new ApplicationException(errormessage);
        }

        public bool AddDownload(string url)
        {
            var request = new RestRequest("/", Method.Get);
            request.AddQueryParameter("mode", "addurl");
            request.AddQueryParameter("output", "json");
            request.AddQueryParameter("apikey", options.ApiKey);
            request.AddQueryParameter("name", url);

            var response = client.GetAsync<SabnzbdAddUrlResult>(request).GetAwaiter().GetResult();
            return response?.Status ?? false;
        }

        public SabnzbdQueue? GetQueue(int start, int limit)
        {
            var request = new RestRequest("/", Method.Get);
            request.AddQueryParameter("mode", "queue");
            request.AddQueryParameter("output", "json");
            request.AddQueryParameter("apikey", options.ApiKey);
            request.AddQueryParameter("start", start.ToString());
            request.AddQueryParameter("limit", limit.ToString());

            var response = client.GetAsync<SabnzbdResult>(request).GetAwaiter().GetResult();
            var data = response;

            return data?.Queue;
        }

        public SabnzbdHistory? GetHistory(int start, int limit)
        {
            var request = new RestRequest("/", Method.Get);
            request.AddQueryParameter("mode", "history");
            request.AddQueryParameter("output", "json");
            request.AddQueryParameter("apikey", options.ApiKey);
            request.AddQueryParameter("start", start.ToString());
            request.AddQueryParameter("limit", limit.ToString());

            var response = client.GetAsync<SabnzbdResult>(request).GetAwaiter().GetResult();
            var data = response;

            return data?.History;
        }
    }
}
