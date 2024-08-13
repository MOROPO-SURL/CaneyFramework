namespace MOROPO.Framework.Caney.Presentation.UI.Views;

public partial class BusyView : MVVM.Core.Views.ContentView
{
    public static readonly Microsoft.Maui.Controls.BindableProperty SpinnerSizeProperty = Microsoft.Maui.Controls.BindableProperty.Create(nameof(SpinnerSize), typeof(double), typeof(Microsoft.Maui.Controls.View), 64.0, Microsoft.Maui.Controls.BindingMode.OneWay, null, SpinnerSizeProperty_Changed);

    public BusyView()
	{
		InitializeComponent();

        ActivitiyIndicator.WidthRequest = 64;
        ActivitiyIndicator.HeightRequest = 64;
    }

    public double SpinnerSize
    {
        get
        {
            return (double)GetValue(SpinnerSizeProperty);
        }
        set
        {
            SetValue(SpinnerSizeProperty, value);
        }
    }

    private static void SpinnerSizeProperty_Changed(Microsoft.Maui.Controls.BindableObject bindable, object oldValue, object newValue)
    {
        ((BusyView)bindable).ActivitiyIndicator.WidthRequest = (double)newValue;
        ((BusyView)bindable).ActivitiyIndicator.HeightRequest = (double)newValue;
    }
}