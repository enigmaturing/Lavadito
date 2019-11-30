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
    }
}