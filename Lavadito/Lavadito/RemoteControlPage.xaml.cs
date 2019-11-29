using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lavadito
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RemoteControlPage : ContentPage
    {
        public RemoteControlPage()
        {
            InitializeComponent();
        }

        private void ButtonON_Clicked(object sender, EventArgs e)
        {
            toggleMotor("on");
        }

        private void ButtonOFF_Clicked(object sender, EventArgs e)
        {
            toggleMotor("off");
        }

        private async void toggleMotor(string s)
        {
            if (tokenEntry.Text == null)
            {
                await DisplayAlert("Alert", "Insert a valid token first!", "OK");
            }
            else
            {
                using (var httpClient = new HttpClient())
                {
                    var formcontent = new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("arg", s) });
                    var request = await httpClient.PostAsync("https://api.particle.io/v1/devices/e00fce68ba9a1f5ea4870186/motorToggle?access_token=" + tokenEntry.Text.ToString(), formcontent);
                }
            }

        }
    }
}