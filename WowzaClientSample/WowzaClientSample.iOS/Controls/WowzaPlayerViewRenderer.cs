using System;
using Plugin.WowzaClient;
using UIKit;
using WowzaClientSample.Controls;
using WowzaClientSample.iOS.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(WowzaPlayerView), typeof(WowzaPlayerViewRenderer))]
namespace WowzaClientSample.iOS.Controls
{
    public class WowzaPlayerViewRenderer : ViewRenderer<WowzaPlayerView, UIView>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<WowzaPlayerView> e)
        {
            base.OnElementChanged(e);

            if(Control == null)
            {
                SetNativeControl(new UIView());
            }

            if (e.NewElement != null)
            {
                WowzaClientManager.AttachPlayerView(Control);
            }
        }
    }
}
