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
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();

            var url = "http://javiergonzalez.de/lavadero/profile.png";
            var byteArray = new System.Net.WebClient().DownloadData(url);
            profileImage.Source = ImageSource.FromStream(() => new System.IO.MemoryStream(byteArray));
        }
    }
}