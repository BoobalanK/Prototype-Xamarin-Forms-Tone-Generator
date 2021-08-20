using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;

using App1.CustomRenderer;
using App1.Droid.CustomRenderer;
using App1.Views;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomWebView), typeof(CustomWebViewRenderer))]
namespace App1.Droid.CustomRenderer
{
    public class CustomWebViewRenderer : WebViewRenderer
    {
        public CustomWebViewRenderer() : base(MainActivity.AppContext)
        {

        }
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.WebView> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                // lets get a reference to the native control
                var webView = (global::Android.Webkit.WebView)Control;
                webView.SetWebViewClient(new MyWebViewClient());
                webView.SetInitialScale(100);
                webView.Settings.JavaScriptEnabled = true;
            }
        }
        protected override FormsWebChromeClient GetFormsWebChromeClient()
        {
            return base.GetFormsWebChromeClient();
        }
    }

    public class MyWebViewClient : WebViewClient
    {
        public override bool ShouldOverrideUrlLoading(Android.Webkit.WebView view, string url)
        {
            base.ShouldOverrideUrlLoading(view, url);
            Debug.WriteLine("Current Url: {0}", url);
            //WebViewPage.CurrentUrl = url;
            view.EvaluateJavascript("javascriptFunction()", new JavaScriptResult());
            return false;
        }
        public override WebResourceResponse ShouldInterceptRequest(Android.Webkit.WebView view, string url)
        {
            return base.ShouldInterceptRequest(view, url);
        }
        public override WebResourceResponse ShouldInterceptRequest(Android.Webkit.WebView view, IWebResourceRequest request)
        {
            if (request.Method.Equals("POST"))
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    var cookieHeader = CookieManager.Instance.GetCookie(view.Url);
                    var cookies = new CookieCollection();
                    var cookiePairs = cookieHeader.Split('&');
                    foreach (var cookiePair in cookiePairs)
                    {
                        var cookiePieces = cookiePair.Split('=');
                        if (cookiePieces[0].Contains(":"))
                            cookiePieces[0] = cookiePieces[0].Substring(0, cookiePieces[0].IndexOf(":"));
                        cookies.Add(new Cookie
                        {
                            Name = cookiePieces[0],
                            Value = cookiePieces[1]
                        });
                    }
                    
                    Debug.WriteLine(cookies.Count);
                });
            }
            return base.ShouldInterceptRequest(view, request);
        }
        public override void OnReceivedHttpAuthRequest(Android.Webkit.WebView view, HttpAuthHandler handler, string host, string realm)
        {
            base.OnReceivedHttpAuthRequest(view, handler, host, realm);
        }
        public override void OnReceivedLoginRequest(Android.Webkit.WebView view, string realm, string account, string args)
        {
            base.OnReceivedLoginRequest(view, realm, account, args);
        }
    }

    public class JavaScriptResult : Java.Lang.Object, IValueCallback
    {
        public void OnReceiveValue(Java.Lang.Object val)
        {
            Debug.WriteLine("Returned value: {0}", val);
        }
    }
}