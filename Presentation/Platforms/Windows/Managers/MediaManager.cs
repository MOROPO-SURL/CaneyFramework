using CommunityToolkit.Maui.Views;

namespace MOROPO.Framework.Caney.Presentation.Platforms.Windows.Managers
{
    internal class MediaManager : CommunityToolkit.Maui.Core.Views.MediaManager
    {
        //private FFme source;

        public MediaManager(Microsoft.Maui.IMauiContext context, CommunityToolkit.Maui.Core.IMediaElement mediaElement, Microsoft.Maui.Dispatching.IDispatcher dispatcher) : base(context, mediaElement, dispatcher)
        {
        }

        protected override void PlatformUpdateSource()
        {
            base.PlatformUpdateSource();

            if (Player is null || MediaElement.Source is null || !(MediaElement.Source is UriMediaSource uriMediaSource))
            {
                return;
            }

            var uri = uriMediaSource.Uri?.AbsoluteUri;
            
            if (string.IsNullOrWhiteSpace(uri) || !(uri.StartsWith("rtsp://") || uri.StartsWith("rtmp://")))
            {
                return;
            }

            //Player.Source = WinMediaSource.CreateFromUri(new System.Uri(uri));
        }
    }
}
