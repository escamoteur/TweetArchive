using System.IO;
using TweetArchive.Model;

namespace TweetArchive.iOS
{
    public class FileStorage : IFileStorage
    {
        public byte[] ReadAsBytes(string filename)
        {
            var data = File.ReadAllBytes(filename);

            if (data != null)
                data = data.CleanByteOrderMark();

            return data;
        }

        public string ReadAsString(string filename)
        {
            var data = ReadAsBytes(filename);

            if (data == null)
                return string.Empty;

            return System.Text.Encoding.UTF8.GetString(data);
        }
    }
}