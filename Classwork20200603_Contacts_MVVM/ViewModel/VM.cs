using Classwork20200603_Contacts_MVVM.Mode;
using Classwork20200603_Contacts_MVVM.ViewModel.Commands;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Classwork20200603_Contacts_MVVM.ViewModel
{
    public class VM : INotifyPropertyChanged
    {
        public ObservableCollection<Contact> Contacts { get; set; } = new ObservableCollection<Contact>();
        public Contact contact;
        public Contact tempContact;

        public Command_Add Command_Add { get; set; }
        public Command_Delete Command_Delete {get;set;}
        public Command_Cleare Command_Cleare { get; set; }
        public Command_Edit Command_Edit { get; set; }
        public Command_Save Command_Save { get; set; }
        public Command_Close Command_Close { get; set; }


        public Contact Contact
        {
            get => contact;
            set
            {
                contact = value;
                OnNotify();
            }
        }
                                 

       
        private Contact selectedContact;
        public Contact SelectedContact
        {
            get => selectedContact;
            set
            {
                selectedContact = value;
                OnNotify();
            }
        }

        //private string name;
        //public string Name
        //{
        //    get => name;
        //    set
        //    {
        //        name = value;
        //        OnNotify();
        //    }
        //}

        //private string surName;
        //public string SurName
        //{
        //    get => surName;
        //    set
        //    {
        //        surName = value;
        //        OnNotify();
        //    }
        //}

        //private string phone;
        //public string Phone
        //{
        //    get => phone;
        //    set
        //    {
        //        phone = value;
        //        OnNotify();
        //    }
        //}


        public VM()
        {
            Contact = new Contact();
            Command_Add = new Command_Add(this);
            Command_Delete = new Command_Delete(this);
            Command_Cleare = new Command_Cleare(this);
            Command_Edit = new Command_Edit(this);
            Command_Save = new Command_Save(this);
            Command_Close = new Command_Close(this);
        }



        public event PropertyChangedEventHandler PropertyChanged;

        // CallerMemberName - дозволяємо автоматично визначити ім'я властивості, яка змінилась в рантаймі

        private void OnNotify([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop)); // обов'язково має бути значення за замовчуванням prop=""

        }


        public void AddContacts()
        {
          Contacts.Add(new Contact { Name = contact.Name, SurName = contact.SurName, Phone = contact.Phone} );            
        }

        public void CleareContact()
        {

            Contact.Name = "";
            Contact.SurName = "";
            Contact.Phone = 1;
            
        }



        public void DeleteContact(Contact selectedContact)
        {
            if (Contacts.Count == 0)
            {
                return;
            }

            Contacts.Remove(selectedContact);
           
        }

        
        
        public void EditContact(Contact selectedContact)
        {
            if (Contacts.Count == 0)
            {
                return;
            }
            tempContact = SelectedContact;
          
        }

        public void CloseContact()
        {
            
        }

        public void SaveContact()
        {

        }



    }
}
