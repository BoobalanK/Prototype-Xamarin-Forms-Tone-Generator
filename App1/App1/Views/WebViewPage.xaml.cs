using App1.DependencyServices;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WebViewPage : ContentPage
    {
        ICookieManagerService _cookieManagerService;
        private string _authUrl;

        public string AuthUrl
        {
            get { return _authUrl; }
            set
            {
                if (_authUrl != value)
                {
                    _authUrl = value;

                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AuthUrl)));
                }
            }
        }
        public new event PropertyChangedEventHandler PropertyChanged;
        public WebViewPage()
        {
            InitializeComponent();
            _cookieManagerService = DependencyService.Get<ICookieManagerService>();
            AuthUrl = "https://uaiapiauthzqytc.azurewebsites.net/api/SignIn/cc_fordtest";
            var cookieContainer = new CookieContainer();
            webView_Auth.Cookies = cookieContainer;
            webView_Auth.Source = AuthUrl;
            webView_Auth.Navigated += WebView_Auth_Navigated;
            webView_Auth.Navigating += WebView_Auth_Navigating;
        }

        private void WebView_Auth_Navigating(object sender, WebNavigatingEventArgs e)
        {
            Debug.WriteLine(e.NavigationEvent);
            switch (e.NavigationEvent)
            {
                case WebNavigationEvent.Back:
                    break;
                case WebNavigationEvent.Forward:
                    break;
                case WebNavigationEvent.NewPage:
                    break;
                case WebNavigationEvent.Refresh:
                    break;
                default:
                    break;
            }
        }

        private async void WebView_Auth_Navigated(object sender, WebNavigatedEventArgs e)
        {
            switch (e.Result)
            {
                case WebNavigationResult.Success:
                    _cookieManagerService.GetCookies(e.Url);
                    break;
                case WebNavigationResult.Cancel:
                    break;
                case WebNavigationResult.Timeout:
                    break;
                case WebNavigationResult.Failure:
                    break;
                default:
                    break;
            }
        }
    }
}