using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Classwork20200601_MVVM.ViewModel.Converters
{
    public class Convert_IsDayTime : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string result = "";
            bool IsDayTime = System.Convert.ToBoolean(value);
            switch (IsDayTime)
            {
                case false:
                    result = "Time: Night";
                    break;
                case true:
                    result = "Time: Day";
                    break;
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
