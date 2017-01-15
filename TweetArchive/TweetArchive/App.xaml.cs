using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TweetArchive.PageModels;
using Xamarin.Forms;
using Xamvvm;

namespace TweetArchive
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // We initialize Xamvvm and register a TabbedPage
            // The linking of Page(View)Models and Pages happens autmatically because PageModels implement IBasePageModel and Pages (IBasePage<PageModel>)
            var factory = new XamvvmFormsRxUIFactory(this);
            factory.RegisterTabbedPage<MainPagePageModel>(new[] {typeof(TweetListPageModel), typeof(SettingsPageModel)});
            XamvvmCore.SetCurrentFactory(factory);
            try
            {
                MainPage = this.GetPageFromCache<MainPagePageModel>() as Page;

            }
            catch (Exception ex)
            {
                
                throw;
            }

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
