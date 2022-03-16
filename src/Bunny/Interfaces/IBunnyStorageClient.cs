namespace pdbme.pdbInfrastructure.Bunny.Interfaces;

public interface IBunnyStorageClient
{
    void UploadFileStream(Stream stream, string storageZone, string accessKey, string targetPath);
}
