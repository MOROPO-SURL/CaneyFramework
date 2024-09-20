namespace MOROPO.Framework.Caney.Presentation.UI.Converters
{
    public class ViewChildParentWidthToRelativeWidthConverter : Microsoft.Maui.Controls.IValueConverter
    {
        public double ReferenceWidth { get; set; }

        public int AbsoluteHorizontalSeparation { get; set; }

        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is not double) return -1;

            var containerWidth = (double)value;

            if (containerWidth == -1) return null;

            var reazon = containerWidth / ReferenceWidth;

            int columnCount = System.Convert.ToInt32(System.Math.Round(reazon, System.MidpointRounding.ToEven));

            if (columnCount > reazon)
            {
                columnCount--;
            }

            return containerWidth / columnCount - AbsoluteHorizontalSeparation;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
