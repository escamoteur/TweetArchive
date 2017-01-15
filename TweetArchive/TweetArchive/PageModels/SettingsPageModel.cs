using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Realms;
using Xamvvm;

namespace TweetArchive.PageModels
{


    public class SettingsPageModel : RealmObject,
                                     IBasePageModel  //We "implement" IBasePageModel so that Xamvvm picks it up as PageModel
    {
        public IList<Category> Categories { get; }
    }


    public class Category : RealmObject
    {
        public string Name { get; set; }
    }

}
