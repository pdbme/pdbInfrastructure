using pdbme.pdbInfrastructure.Helpers.Interfaces;
using System.Text;

namespace pdbme.pdbInfrastructure.Helpers.Services;

public class OpenSubtitlesHash : IOpenSubtitlesHash
{
    public string ComputeHash(string filepath)
    {
        var oshash = string.Empty;

        if (!File.Exists(filepath))
        {
            return oshash;
        }

        byte[] hash;
        using (var fileStream = File.OpenRead(filepath))
        {
            hash = ComputeHashFromStream(fileStream);
        }

        StringBuilder hexBuilder = new StringBuilder();
        for (int i = 0; i < hash.Length; i++)
        {
            hexBuilder.Append(hash[i].ToString("x2"));
        }

        oshash = hexBuilder.ToString();

        return oshash;
    }

    private byte[] ComputeHashFromStream(Stream input)
    {
        using (input)
        {
            long lhash, streamsize;
            streamsize = input.Length;
            lhash = streamsize;

            long i = 0;
            byte[] buffer = new byte[sizeof(long)];
            while (i < 65536 / sizeof(long) && input.Read(buffer, 0, sizeof(long)) > 0)
            {
                i++;
                lhash += BitConverter.ToInt64(buffer, 0);
            }

            input.Position = Math.Max(0, streamsize - 65536);
            i = 0;
            while (i < 65536 / sizeof(long) && input.Read(buffer, 0, sizeof(long)) > 0)
            {
                i++;
                lhash += BitConverter.ToInt64(buffer, 0);
            }

            byte[] result = BitConverter.GetBytes(lhash);
            Array.Reverse(result);

            return result;
        }
    }
}
