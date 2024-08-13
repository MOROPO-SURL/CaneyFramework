namespace MOROPO.Framework.Caney.MVVM.Core.Pages
{
    public class FlyoutPage : Microsoft.Maui.Controls.FlyoutPage, System.IDisposable
    {
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            if (!disposedValue) return;

            if (Flyout is Microsoft.Maui.Controls.ContentPage)
            {
                (Flyout as Microsoft.Maui.Controls.ContentPage).Content = null;
            }
            else if (Flyout is Microsoft.Maui.Controls.MultiPage<Microsoft.Maui.Controls.Page>)
            {
                foreach (var child in (Flyout as Microsoft.Maui.Controls.MultiPage<Microsoft.Maui.Controls.Page>).Children)
                {
                    if (child is Microsoft.Maui.Controls.ContentPage)
                    {
                        (child as Microsoft.Maui.Controls.ContentPage).Content = null;
                    }
                }
            }

            if (Detail is Microsoft.Maui.Controls.ContentPage)
            {
                (Detail as Microsoft.Maui.Controls.ContentPage).Content = null;
            }
            else if (Detail is Microsoft.Maui.Controls.MultiPage<Microsoft.Maui.Controls.Page>)
            {
                foreach (var child in (Detail as Microsoft.Maui.Controls.MultiPage<Microsoft.Maui.Controls.Page>).Children)
                {
                    if (child is Microsoft.Maui.Controls.ContentPage)
                    {
                        (child as Microsoft.Maui.Controls.ContentPage).Content = null;
                    }
                }
            }

            System.GC.Collect();
        }

        #region IDisposable Support
        private bool disposedValue = false; // Para detectar llamadas redundantes

        private void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: elimine el estado administrado (objetos administrados).
                    DisposeManagementResources();
                }

                // TODO: libere los recursos no administrados (objetos no administrados) y reemplace el siguiente finalizador.
                // TODO: configure los campos grandes en nulos.

                DisposeUnmanagementResources();

                if (Flyout is System.IDisposable)
                {
                    (Flyout as System.IDisposable).Dispose();
                }

                if (Detail is System.IDisposable)
                {
                    (Detail as System.IDisposable).Dispose();
                }

                if (BindingContext is System.IDisposable)
                {
                    (BindingContext as System.IDisposable).Dispose();
                }

                disposedValue = true;

                BindingContext = null;
            }
        }

        protected virtual void DisposeManagementResources() { }

        protected virtual void DisposeUnmanagementResources() { }

        // TODO: reemplace un finalizador solo si el anterior Dispose(bool disposing) tiene código para liberar los recursos no administrados.
        // ~ContentPage() {
        //   // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
        //   Dispose(false);
        // }

        // Este código se agrega para implementar correctamente el patrón descartable.
        public void Dispose()
        {
            // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
            Dispose(true);
            // TODO: quite la marca de comentario de la siguiente línea si el finalizador se ha reemplazado antes.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
