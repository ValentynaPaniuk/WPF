using Classwork20200603_Contacts_MVVM.Mode;
using Classwork20200603_Contacts_MVVM.ViewModel.Commands;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Classwork20200603_Contacts_MVVM.ViewModel
{
    public class VM : INotifyPropertyChanged
    {
        public ObservableCollection<Contact> Contacts { get; set; } = new ObservableCollection<Contact>();
       
        public Command_Add Command_Add { get; set; }
        public Command_Delete Command_Delete {get;set;}
        public Command_Cleare Command_Cleare { get; set; }
        public Command_Edit Command_Edit { get; set; }
        public Command_Save Command_Save { get; set; }
        public Command_Close Command_Close { get; set; }


        bool visibleEdit = false;
        bool visibleCreate = true;

        public Contact contact;
        public Contact Contact
        {
            get => contact;
            set
            {
                contact = value;
                OnNotify();
            }
        }

        public Contact tempContact;
        public Contact TempContact
        {
            get => tempContact;
            set
            {
                tempContact = value;
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


        public bool VisibleEdit
        {
            get => visibleEdit;
            set
            {
                visibleEdit = value;
                OnNotify();
            }
        }
        public bool VisibleCreated
        {
            get => visibleCreate;
            set
            {
                visibleCreate = value;
                OnNotify();
            }
        }




        public VM()
        {
            Contact = new Contact();
            tempContact = new Contact();

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
            Contact = null;
            Contact = new Contact();
            
        }



        public void DeleteContact(int phone)
        {
            if (Contacts.Count == 0)
            {
                return;
            }
            if (SelectedContact != null && SelectedContact.Phone == phone)
            {
                Contacts.Remove(SelectedContact);
                Contact = new Contact();
               
            }
           
        }

     

        public void EditContact()
        {
            if (Contacts.Count == 0)
            {
                return;
            }
            TempContact = SelectedContact;
                                 
            ChangeVisible();


        }

      

        public void SaveContact()
        {
            for (int i = 0; i < Contacts.Count; i++)
            {
                if (SelectedContact == Contacts[i])
                    Contacts[i] = TempContact;
            }
            Contact = new Contact();
            ChangeVisible();

        }

        public void CloseContact()
        {
            for (int i = 0; i < Contacts.Count; i++)
            {
                if (SelectedContact.Phone != TempContact.Phone)
                    SelectedContact.Phone = Contacts[i].Phone;
            }
            TempContact = null;
            ChangeVisible();

        }

        private void ChangeVisible()
        {
            VisibleEdit = !VisibleEdit;
            VisibleCreated = !VisibleCreated;
        }


    }
}
