namespace MOROPO.Framework.Caney.Presentation.UI.Converters
{
    public class DoubleToFactorConverter : Microsoft.Maui.Controls.IValueConverter
    {
        public object Convert(object rawValue, System.Type targetType, object rawParameter, System.Globalization.CultureInfo culture)
        {
            var value = System.Convert.ToDouble(rawValue);
            var paramenter = System.Convert.ToDouble(rawParameter, System.Globalization.CultureInfo.InvariantCulture);

            return value * paramenter;
        }

        public object ConvertBack(object rawValue, System.Type targetType, object rawParameter, System.Globalization.CultureInfo culture)
        {
            var value = System.Convert.ToDouble(rawValue);
            var paramenter = System.Convert.ToDouble(rawParameter, System.Globalization.CultureInfo.InvariantCulture);

            return value / paramenter;
        }
    }
}
