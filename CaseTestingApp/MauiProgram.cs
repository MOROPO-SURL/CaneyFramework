using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Compatibility.Hosting;
using Microsoft.Maui.LifecycleEvents;
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Windows.Devices.Display;
using Windows.Devices.Enumeration;
using Windows.Graphics;

namespace CaseTestingApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCompatibility()
                .UseMauiCommunityToolkit()
                .UseMauiCommunityToolkitMediaElement()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if WINDOWS

            builder.ConfigureLifecycleEvents(events =>
            {
                events.AddWindows(wndLifeCycleBuilder =>
                {
                    wndLifeCycleBuilder.OnWindowCreated(windowCreationDelegate =>
                    {
                        IntPtr nativeWindowHandle = WinRT.Interop.WindowNative.GetWindowHandle(windowCreationDelegate);
                        var win32WindowsId = Win32Interop.GetWindowIdFromWindow(nativeWindowHandle);
                        var winuiAppWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(win32WindowsId);

                        //int width = 1680;
                        //int height = 1000; //1050;
                        //winuiAppWindow.MoveAndResize(new Windows.Graphics.RectInt32(0, 0, width, height));

                        Task.Run(async () => await SizeWindow(winuiAppWindow));

                        //winuiAppWindow.SetPresenter(AppWindowPresenterKind.Overlapped);
                    });
                });
            });

#endif

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

#if WINDOWS
        private static async Task SizeWindow(Microsoft.UI.Windowing.AppWindow appWindow)
        {
            var displayList = await DeviceInformation.FindAllAsync(DisplayMonitor.GetDeviceSelector());

            if (!displayList.Any()) return;

            var winSize = new SizeInt32();

            foreach (var display in displayList)
            {
                var monitorInfo = await DisplayMonitor.FromInterfaceIdAsync(display.Id);

                winSize.Height += monitorInfo.NativeResolutionInRawPixels.Height;
                winSize.Width += monitorInfo.NativeResolutionInRawPixels.Width;
            }

            appWindow.Resize(winSize);
        }
#endif
    }
}