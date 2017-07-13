using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TweetArchive.PageModels;
using Xamarin.Forms;
using Xamvvm;

namespace TweetArchive.Pages
{
    // We cannot use the XamvvmRxUI convenient classes as BaseClasses because they expect an from ReactiveObject derived PageModel
    // So we derive from ReactiveContentPage and implement IBasePage so that the Page will be picked up by Xamvvm

    public partial class SettingsPage : IBasePage<SettingsPageModel>
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            System.Diagnostics.Debug.WriteLine("----------------------------SettingsPage OnAppearing");

        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            System.Diagnostics.Debug.WriteLine("------------------------------SettingsPage OnDisappearing");
        }
    }
}
