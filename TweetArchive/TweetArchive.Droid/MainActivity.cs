using System;
using System.IO;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using BoxKite.Twitter;
using Splat;
using TweetArchive.Model;

namespace TweetArchive.Droid
{
    [Activity(Label = "TweetArchive", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);



            //BoxKite.Twitter need a Platformspecific adapter, so we create it here and register in in Splat so that we can access it in the PCL
            Locator.CurrentMutable.RegisterConstant(new AndroidPlatformAdaptor(),typeof(IPlatformAdaptor));

            //Registering platform specific config reader more on this pattern see https://xamarinhelp.com/configuration-files-xamarin-forms/
            try
            {
                Locator.CurrentMutable.RegisterLazySingleton(() => ConfigurationService.Read(new FileStorage()), typeof(IConfiguration));
            }
            catch (System.Exception x)
            {
                throw new FileNotFoundException("No config File", x);
            }


            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());

#if DEBUG
            UISleuth.Inspector.Init();
#endif
        }
    }
}

