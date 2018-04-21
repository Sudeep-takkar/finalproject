using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace finalproject.User
{
    [ValueConversion(typeof(int), typeof(Brush))]
    class ContactConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            UInt64 i = UInt64.Parse(value.ToString());
            if (1000000000 < i && i < 10000000000)
            {
                return Brushes.Black;
            }
            else
            {
                return Brushes.Red;
            }
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
