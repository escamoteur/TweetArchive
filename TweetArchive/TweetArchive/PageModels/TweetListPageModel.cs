using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
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

            //  Publish a Live query on all Object of Type TweetViewModel
            //  So that we can bind to it from the Page.
            //  realm.All<TweetViewModel>()   only returns a IQueriable which does not raise any change events.
            //  With the extension method "AsRealmCollection" we can get the underlying RealmCollection object which has this events
            TweetViewModels = realm.All<TweetViewModel>().AsRealmCollection();


            // Another possibility to get informed about changes is to register a callback 
            // This allows to react on any write transaction
            realm.All<TweetViewModel>().SubscribeForNotifications(Callback);



            // The RxUI way to react on such changes WhenAnyValue returns an Observable that issues an value when ever the value of the observed Property changes
            // Here we observe "TweetViewModels.Count"
            this.WhenAnyValue(x => x.TweetViewModels.Count)
                .Subscribe(i =>
                {
                    System.Diagnostics.Debug.WriteLine("Number of Records: " + i.ToString());
                });

        }

        // Just to demonstrate the possibility of a Realm change callback
        private void Callback(IRealmCollection<TweetViewModel> sender, ChangeSet changes, Exception error)
        {
        }
    }
}
