using System.Linq;
using Newtonsoft.Json;

namespace TweetArchive.Model
{

    //We use this to separate our App configuration from the solution more on this pattern see https://xamarinhelp.com/configuration-files-xamarin-forms/
    // Here I use it to not having to include the APIKey and Secret of my Twitter App in my GitHub Repo
    // To achieve this we include our config.json file to our Assets/Resources only a LinkedFile

    public interface IConfiguration
    {
        string ApiKey { get; }
        string ApiSecret { get; }
	}

    class TweetAcriveConfiguration : IConfiguration
    {
        public string ApiKey { get; set; }
        public string ApiSecret { get; set; }
    }


    public interface IFileStorage
    {
        string ReadAsString(string filename);
        byte[] ReadAsBytes(string filename);
    }


    public static class ConfigurationService
    {

        public static byte[] CleanByteOrderMark(this byte[] bytes)
        {
            var bom = new byte[] { 0xEF, 0xBB, 0xBF };
            var empty = Enumerable.Empty<byte>();
            if (bytes.Take(3).SequenceEqual(bom))
                return bytes.Skip(3).ToArray();

            return bytes;
        }

        public static IConfiguration Read(IFileStorage fileStorage)
        {
            var platformFile = fileStorage.ReadAsString("config.json");

            var configuration = JsonConvert.DeserializeObject<TweetAcriveConfiguration>(platformFile);

            return configuration;
        }


    }
}
