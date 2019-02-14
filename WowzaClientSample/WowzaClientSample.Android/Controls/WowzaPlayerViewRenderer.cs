using System;
using System.Threading.Tasks;
using Android.Content;
using Com.Wowza.Gocoder.Sdk.Api.Player;
using Com.Wowza.Gocoder.Sdk.Api.Status;
using Plugin.WowzaClient;
using WowzaClientSample.Controls;
using WowzaClientSample.Droid.Controls;
using WowzaClientSample.Models;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(WowzaPlayerView), typeof(WowzaPlayerViewRenderer))]
namespace WowzaClientSample.Droid.Controls
{
    public class WowzaPlayerViewRenderer : ViewRenderer<WowzaPlayerView, WOWZPlayerView>
    {
        public WowzaPlayerViewRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<WowzaPlayerView> e)
        {
            base.OnElementChanged(e);

            if(Control == null)
            {
                SetNativeControl(new WOWZPlayerView(Context));
            }

            if(e.NewElement != null)
            {
                WowzaClientManager.AttachPlayerView(Control);
            }
        }
    }
}
