using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Classwork20200601_MVVM.ViewModel.Converters
{
    class Convert_Precipitation_to_YesNone : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string result = "";
            bool Presipitations_YesNone = System.Convert.ToBoolean(value);
            switch (Presipitations_YesNone)
            {
                case false:
                    result = "Precipitation: none";
                    break;
                case true:
                    result = "Precipitation: yes";
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
