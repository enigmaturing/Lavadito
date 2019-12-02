using Microsoft.AppCenter.Crashes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lavadito
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : MasterDetailPage
    {

        // Dummy-dictionary that holds the info about the actual user
        Dictionary<string, string> userInfo = new Dictionary<string, string>
         {
             {"user", "javier@javier.es" },
             {"network", "WiFi" }
         };

        public MasterPage()
        {
            InitializeComponent();
            Detail = new NavigationPage(new ProfilePage());
        }

        private void Button_Clicked_Profile(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new ProfilePage());
            IsPresented = false;
        }

        private void Button_Clicked_Vouchers(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new VouchersPage());
            IsPresented = false;
        }

        private void Button_Clicked_RemoteControl(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new RemoteControlPage());
            IsPresented = false;
        }

        private void Button_Clicked_CarshSimulationWithAppCenterFunction(object sender, EventArgs e)
        {
            Crashes.GenerateTestCrash();
        }

        private void Button_Clicked_CarshSimulationWithException(object sender, EventArgs e)
        {
            throw new Exception("Simulating a crash using an exception");
        }

        // Solves issue #19: Catch carshes and report them as errors
        private void Button_Clicked_ReportCrashAsAnError(object sender, EventArgs e)
        {
            try
            {
                throw new Exception(); // We simulate an app crash by thrwoing an exception
            }
            catch (Exception ex)
            {
                AppCenterHelper.TrackError(ex, userInfo);
            }
        }
    }
}