using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System.Collections.Generic;

namespace Lavadito
{
    public partial class App : Application
    {

        // Dummy-dictionary that holds the info about the actual user
        Dictionary<string, string> userInfo = new Dictionary<string, string>
         {
             {"user", "javier@javier.es" },
             {"network", "WiFi" }
         };

        public App()
        {
            InitializeComponent();

            MainPage = new MasterPage();
        }

        protected override async void OnStart()
        {
            // Handle when your app starts
            AppCenter.Start("android=f93b9933-3135-4a2c-bc1d-7b2c4bb2439c;ios=aeaed092-f87c-465f-8916-c23f13c7fa81", typeof(Analytics), typeof(Crashes));

            // ISSUE #12
            // Check if the app crashed on last session
            bool didAppCrash = await Crashes.HasCrashedInLastSessionAsync();
            if (didAppCrash)
                await MainPage.DisplayAlert("Sorry for that!", "It seems like the app crashed before."+ Environment.NewLine +"We are working on that issue to fix it.", "It's ok!");

            // ISSUE #11
            // Call the Method TrackEvent() of the package Microsoft.AppCenter.Analytics, through the helper class AppCenterHelper
            // This helper class helps us to group all methods related to AppCenter, modifing its behaviour when necessary
            AppCenterHelper.TrackEvent("user started the app", userInfo);
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes

            // ISSUE #11
            // Call the Method TrackEvent() of the package Microsoft.AppCenter.Analytics, through the helper class AppCenterHelper
            // This helper class helps us to group all methods related to AppCenter, modifing its behaviour when necessary
            AppCenterHelper.TrackEvent("user resumed the app", userInfo);
        }
    }
}
