using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classwork20200605_Contacts_Pages
{
    public class Contact : INotifyPropertyChanged
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
        string surname;
        public string Surname
        {
            get => surname; set
            {
                surname = value;
                OnNotify("Surname");
            }
        }
        public int Age { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnNotify(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
