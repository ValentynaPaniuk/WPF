using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Classwork20200605_Contacts_Pages.Controls
{
    /// <summary>
    /// Логика взаимодействия для ContactControl.xaml
    /// </summary>
    public partial class ContactControl : UserControl
    {
        // Реєструємо властивість залежностей StudentProperty, бо без DependencyProperty не можна робити Binding
        public static readonly DependencyProperty ContactProperty = DependencyProperty.Register("Contact", typeof(Contact),
                                                                            typeof(ContactControl), new PropertyMetadata(null, SetContact));

        private static void SetContact(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ContactControl control = d as ContactControl;
            control.nameControl.Content = (e.NewValue as Contact).Name;
            control.surnameControl.Content = (e.NewValue as Contact).Surname;
            control.ageControl.Content = (e.NewValue as Contact).Age;
        }


        public ContactControl()
        {
            InitializeComponent();
          
        }


        // Звичайна публічна властивість
        public Contact Contact
        {
            get
            {
                return (Contact)GetValue(ContactProperty);
            }
            set
            {
                SetValue(ContactProperty, value);
            }
        }

    }
}
