namespace MOROPO.Framework.Caney.MVVM.Core.Extensions
{
    public static class PageNavigationExtensions
    {
        public static System.Threading.Tasks.Task NavigationPushPageAsync(this Microsoft.Maui.Controls.Page target, Microsoft.Maui.Controls.Page page, bool animate = true)
        {
            return target.Navigation.PushAsync(page, animate);
        }

        public static System.Threading.Tasks.Task NavigationPushModalPageAsync(this Microsoft.Maui.Controls.Page target, Microsoft.Maui.Controls.Page page, bool animate = true)
        {
            return target.Navigation.PushModalAsync(page, animate);
        }

        public static System.Threading.Tasks.Task NavigationPopPageAsync(this Microsoft.Maui.Controls.Page target, bool animate = true, System.Action<Microsoft.Maui.Controls.Page> callbackAction = null)
        {
            return target.Navigation.PopAsync(animate).ContinueWith((System.Threading.Tasks.Task<Microsoft.Maui.Controls.Page> task) =>
            {
                task.Result.Dispatcher.Dispatch(() =>
                {
                    callbackAction?.Invoke(task.Result);

                    if (task.Result is System.IDisposable)
                    {
                        (task.Result as System.IDisposable).Dispose();
                    }
                });
            });
        }

        public static System.Threading.Tasks.Task NavigationPopPageAsync(this Microsoft.Maui.Controls.Page target, System.Action<Microsoft.Maui.Controls.Page> callbackAction)
        {
            return target.NavigationPopPageAsync(true, callbackAction);
        }

        public static System.Threading.Tasks.Task NavigationPopModalPageAsync(this Microsoft.Maui.Controls.Page target, bool animate = true, System.Action<Microsoft.Maui.Controls.Page> callbackAction = null)
        {
            return target.Navigation.PopModalAsync(animate).ContinueWith((System.Threading.Tasks.Task<Microsoft.Maui.Controls.Page> task) =>
            {
                task.Result.Dispatcher.Dispatch(() =>
                {
                    callbackAction?.Invoke(task.Result);

                    if (task.Result is System.IDisposable)
                    {
                        (task.Result as System.IDisposable).Dispose();
                    }
                });
            });
        }

        public static System.Threading.Tasks.Task NavigationPopModalPageAsync(this Microsoft.Maui.Controls.Page target, System.Action<Microsoft.Maui.Controls.Page> callbackAction)
        {
            return target.NavigationPopModalPageAsync(true, callbackAction);
        }
    }
}
