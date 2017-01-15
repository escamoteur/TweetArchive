using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Realms;
using Xamvvm;

namespace TweetArchive.ViewModels
{
    public class TweetViewModel : RealmObject
    {
        public string Text { get; set; }

        public DateTimeOffset Time { get; set; }

        public long Id { get; set; }

        public string Source { get; set; }

        public bool Favourited { get; set; }

        public Entities Entities { get; set; }

        public Entities ExtendedEntities { get; set; }

        public int FavoriteCount { get; set; }




    }

    public class Entities  : RealmObject
    {
        public IList<Url> Urls { get; }

        public IList<Hashtag> Hashtags { get; }

        public IList<Media> Media { get;  }
    }


    public class Url : RealmObject
    {

        public string _Url { get; set; }

        public string DisplayUrl { get; set; }

        public string ExpandedUrl { get; set; }
    }

    public class Hashtag : RealmObject
    {
        public string Text { get; set; }

    }


    public class Media : RealmObject
    {
        public string Type { get; set; }

        public Sizes Sizes { get; set; }

        public string Url { get; set; }

        public string MediaUrl { get; set; }

        public string DisplayUrl { get; set; }

        public long Id { get; set; }

        public string ExpandedUrl { get; set; }

        public string MediaUrlHttps { get; set; }

    }

    public class Sizes : RealmObject
    {
        public ImageSizeType Thumb { get; set; }

        public ImageSizeType Large { get; set; }

        public ImageSizeType Medium { get; set; }

        public ImageSizeType Small { get; set; }
    }

    public class ImageSizeType : RealmObject
    {
        public int Height { get; set; }

        public string Resize { get; set; }

        public int Width { get; set; }
    }


}
