namespace pdbme.pdbInfrastructure.Bunny.Interfaces;

[Obsolete("Use BunnyStorageClient instead.")]
public interface IBunnyApiClient
{
    void setStorageZone(string storageZone);
    void setAccessKey(string accessKey);
    void UploadFileStream(Stream stream, string targetPath);
}
