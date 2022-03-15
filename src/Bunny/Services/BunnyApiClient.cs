using Microsoft.Extensions.Options;
using pdbme.pdbInfrastructure.Bunny.Interfaces;
using pdbme.pdbInfrastructure.Bunny.Options;
using System.Security.Cryptography;

namespace pdbme.pdbInfrastructure.Bunny.Services;

public class BunnyApiClient : IBunnyApiClient
{
    private BunnyApiOptions options;
    private readonly HttpClient httpClient;

    public BunnyApiClient(IOptions<BunnyApiOptions> options, HttpClient httpClient)
    {
        this.options = options?.Value ?? new BunnyApiOptions();
        this.httpClient = httpClient;
    }

    public void setStorageZone(string storageZone)
    {
        options.StorageZone = storageZone;
    }

    public void setAccessKey(string accessKey)
    {
        options.AccessKey = accessKey;
    }

    public void UploadFileStream(Stream stream, string targetPath)
    {
        var normalizedPath = $"{options.BaseUrl}/" + $"{options.StorageZone}/{targetPath.Replace("\\", "/")}";
        using (var content = new StreamContent(stream))
        {
            var message = new HttpRequestMessage(HttpMethod.Put, normalizedPath)
            {
                Content = content
            };


            if (!stream.CanSeek)
                throw new ApplicationException("Unable to generate checksum for non-seekable stream.", null);

            long startPosition = stream.Position;
            var sha256Checksum = Checksum.Generate(stream);
            stream.Position = startPosition;

            message.Headers.Add("AccessKey", options.AccessKey);

            if (!string.IsNullOrWhiteSpace(sha256Checksum))
                message.Headers.Add("Checksum", sha256Checksum);

            //if (!string.IsNullOrWhiteSpace(contentTypeOverride))
            //    message.Headers.Add("Override-Content-Type", contentTypeOverride);

            var response = httpClient.Send(message);
            var s = response.EnsureSuccessStatusCode();
            /*
            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.BadRequest && !string.IsNullOrWhiteSpace(sha256Checksum))
                    throw new ApplicationException("Excp: " + normalizedPath + " Checksum: " + sha256Checksum);
                else
                    throw new ApplicationException("Excp: " + normalizedPath + " StatusCode: " + response.StatusCode +" Reason: " + response.ReasonPhrase);
            }
            */
        }
    }
    internal class Checksum
    {
        internal static string Generate(Stream stream)
        {
            var checksumData = SHA256.Create().ComputeHash(stream);
            return BitConverter.ToString(checksumData).Replace("-", string.Empty);
        }
    }
}
