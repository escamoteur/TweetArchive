using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Realms;
using TweetArchive.Model;
using TweetArchive.ViewModels;
using Xamvvm;

namespace TweetArchive.PageModels
{
    public class TweetListPageModel : BasePageModelRxUI
    {

        public IRealmCollection<TweetViewModel> TweetViewModels { get; set; }

        public TweetListPageModel()
        {
            var realm = RealmDB.Instance;
            TweetViewModels= realm.All<TweetViewModel>().AsRealmCollection();

            realm.All<TweetViewModel>().SubscribeForNotifications(Callback);

        }

        private void Callback(IRealmCollection<TweetViewModel> sender, ChangeSet changes, Exception error)
        {
        }
    }
}
