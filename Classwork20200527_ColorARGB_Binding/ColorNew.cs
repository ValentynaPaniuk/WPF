using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classwork20200527_ColorRGB
{
    public class ColorNew : INotifyPropertyChanged
    {
        string name;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnNotify("Name");
            }
        }


        public string fontName;
        public string FontName
        {
            get => fontName;
            set
            {
                fontName = value;
                OnNotify("FontName");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnNotify(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }

}
