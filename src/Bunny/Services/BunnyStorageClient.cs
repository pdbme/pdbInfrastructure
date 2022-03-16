using pdbme.pdbInfrastructure.Bunny.Interfaces;
using System.Security.Cryptography;

namespace pdbme.pdbInfrastructure.Bunny.Services;

public class BunnyStorageClient : IBunnyStorageClient
{
    private readonly HttpClient httpClient;

    public BunnyStorageClient(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public void UploadFileStream(Stream stream, string storageZone, string accessKey, string targetPath)
    {
        var normalizedPath = "https:" + "//storage.bunnycdn.com/" + $"{storageZone}/{targetPath.Replace("\\", "/")}";
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

            message.Headers.Add("AccessKey", accessKey);

            if (!string.IsNullOrWhiteSpace(sha256Checksum))
                message.Headers.Add("Checksum", sha256Checksum);

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
