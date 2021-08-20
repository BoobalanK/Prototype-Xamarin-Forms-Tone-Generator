using App1.Views;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ToneTypes_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ToneTypesPage());
        }
        private void WebView_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WebViewPage());
        }

    }
}
