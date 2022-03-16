namespace pdbme.pdbInfrastructure.Bunny.Options;

[Obsolete("Use BunnyStorageClient instead.")]
public class BunnyApiOptions
{
    public string BaseUrl { get; set; } = "https:" + "//storage.bunnycdn.com";
    public string StorageZone { get; set; } = "";
    public string AccessKey { get; set; } = "";
}
