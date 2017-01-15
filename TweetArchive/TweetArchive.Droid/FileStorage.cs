using System.IO;
using System.Text;
using Android.Content.Res;
using TweetArchive.Model;


namespace TweetArchive.Droid
{
    public class FileStorage : IFileStorage
    {
 
        public string ReadAsString(string filename)
        {
            var bytes = ReadAsBytes(filename);
            return Encoding.UTF8.GetString(bytes.CleanByteOrderMark());
        }

        public byte[] ReadAsBytes(string filename)
        {
            AssetManager assets = Android.App.Application.Context.Assets;
            using (Stream stream = assets.Open(filename))
            {
                using (var memStream = new MemoryStream())
                {
                    stream.CopyTo(memStream);
                    return memStream.ToArray();
                }
            }
        }
    }
}