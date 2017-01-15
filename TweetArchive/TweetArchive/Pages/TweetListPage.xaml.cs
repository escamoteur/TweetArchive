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
    public partial class TweetListPage 
    {
        public TweetListPage()
        {
            InitializeComponent();

            this.WhenActivated(d =>
            {
                ViewModel = (TweetListPageModel)BindingContext;

                this.OneWayBind(ViewModel, vm => vm.TweetViewModels.Count, v => v.NumOfTweets.Text, x=>x.ToString());

                //We could also easily observe properties of the PageModel
                //this.WhenAnyValue(x => x.ViewModel.TweetViewModels.Count).Subscribe(OnNext);
            });
        }


        private void OnNext(int numberOfTweets)
        {
            System.Diagnostics.Debug.WriteLine("Number of Records: " + numberOfTweets);
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
        }
    }
}
