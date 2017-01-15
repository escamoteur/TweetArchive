using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using Realms;
using TweetArchive.PageModels;
using TweetArchive.ViewModels;
using Xamarin.Forms;
using Xamvvm;

namespace TweetArchive.Pages
{
    public partial class TweetListPage : IBasePage<TweetListPageModel>
    {
        public TweetListPage()
        {
            InitializeComponent();

            this.WhenActivated(d =>
            {
                this.OneWayBind(ViewModel, vm => vm.TweetViewModels, v => v.NumOfTweets.Text, x =>
                {
                    return x.Count.ToString();
                });

                this.WhenAnyValue(x => x.ViewModel.TweetViewModels).Subscribe(OnNext);
            });
        }

        private void OnNext(IRealmCollection<TweetViewModel> tweetViewModels)
        {
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
        }
    }
}
