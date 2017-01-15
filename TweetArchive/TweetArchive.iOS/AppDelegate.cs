using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BoxKite.Twitter;
using Foundation;
using Splat;
using TweetArchive.Model;
using UIKit;
using BoxKite.Twitter;

namespace TweetArchive.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {

            //BoxKite.Twitter need a Platformspecific adapter, so we create it here and register in in Splat so that we can access it in the PCL
            Locator.CurrentMutable.RegisterConstant(new IOSPlatformAdaptor(), typeof(IPlatformAdaptor));

            //Registering platform specific config reader more on this pattern see https://xamarinhelp.com/configuration-files-xamarin-forms/
            try
            {
                Locator.CurrentMutable.RegisterLazySingleton(() => ConfigurationService.Read(new FileStorage()), typeof(IConfiguration));
            }
            catch (System.Exception x)
            {
                throw new FileNotFoundException("No config File", x);
            }


            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
