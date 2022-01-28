using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Giftcards.WPF.Converters
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        //bool to visibility
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isChecked = System.Convert.ToBoolean(value);
            return isChecked ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
        }

        //visibility to bool
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
