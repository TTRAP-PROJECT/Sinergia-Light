using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using firstMobileApp.Class;

namespace firstMobileApp.Class
{
    internal class UsersModel : INotifyPropertyChanged
    {
        API api;
        private ObservableCollection<Users> _usersList;

        public ObservableCollection<Users> UsersList
        {
            get { return _usersList; }
            set
            {
                if (_usersList != value)
                {
                    _usersList = value;
                    OnPropertyChanged(nameof(UsersList));
                }
            }
        }

        public UsersModel()
        {
            api = new API();
            UsersList = new ObservableCollection<Users>();
            api.GetPostData();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
