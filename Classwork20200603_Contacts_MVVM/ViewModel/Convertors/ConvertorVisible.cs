using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Classwork20200603_Contacts_MVVM.ViewModel.Convertors
{
    public class ConvertorVisible : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool colaps = System.Convert.ToBoolean(value);
            Visibility tmp = new Visibility();
            if (colaps)
                tmp = Visibility.Visible;
            else
                tmp = Visibility.Collapsed;

            return tmp;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
