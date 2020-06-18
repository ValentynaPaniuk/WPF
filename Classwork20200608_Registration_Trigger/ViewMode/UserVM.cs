using Classwork20200608_Registration_Trigger.Mode;
using Classwork20200608_Registration_Trigger.ViewMode.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Classwork20200608_Registration_Trigger.ViewMode
{
    public class UserVM : INotifyPropertyChanged
    {

        public ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>();

        public Command_Registration Command_Regisration;

        string answer;
        public string Answer
        {
            get => answer;
            set
            {
                answer = value;
                OnNotify();
            }
        }


        public User user;
        public User User
        {
            get => user;
            set
            {
                user = value;
                OnNotify();
            }
        }


        //public string firstName;
        //public string FirstName
        //{
        //    get => firstName;
        //    set
        //    {
        //        firstName = value;
        //        OnNotify();
        //    }
        //}

        //public string lastName;
        //public string LastName
        //{
        //    get => lastName;
        //    set
        //    {
        //        lastName = value;
        //        OnNotify();
        //    }
        //}

        //public string email;
        //public string Email
        //{
        //    get => email;
        //    set
        //    {
        //        email = value;
        //        OnNotify();
        //    }
        //}

        //public string password;
        //public string Password
        //{
        //    get => password;
        //    set
        //    {
        //        password = value;
        //        OnNotify();
        //    }
        //}


        //public DateTime birthday;
        //public DateTime Birthday
        //{
        //    get => birthday;
        //    set
        //    {
        //        birthday = value;
        //        OnNotify();
        //    }
        //}

        //public string gender;
        //public string Gender
        //{
        //    get => gender;
        //    set
        //    {
        //        gender = value;
        //        OnNotify();
        //    }
        //}

        public UserVM()
        {
            User = new User();
            Command_Regisration = new Command_Registration(this);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnNotify([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }


        public void AddUsers()
        {
            
            Users.Add(new User { FirstName = User.FirstName, LastName = User.LastName, Email = User.Email, Phone=User.Phone, Birthday = User.Birthday, Gender = User.Gender, Password = User.Password });
                    Answer = "We have this User 1111";
                    //user = null;
                    //user = new User();
                

                //else
                //{
                //    Answer = "We have this User 2222";
                //}

            }
           
     }



    
}
