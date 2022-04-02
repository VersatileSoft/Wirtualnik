using System;
using System.Globalization;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Wirtualnik.XF.Converters
{
    public class ReturnWithDelayConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Task.Delay(250);

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
