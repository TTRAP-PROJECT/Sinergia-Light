using firstMobileApp.Class;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstMobileApp.Models
{
    internal class ServicesModel : INotifyPropertyChanged
    {
        API api;
        private ObservableCollection<Users> _usersList;



        public ServicesModel()
        {
            api = new API();
            UsersList = new ObservableCollection<Users>();
            LoadData();
        }

        private async void LoadData()
        {
            var result = await api.GetPostData("/users");
            List<Users> usersList = JsonConvert.DeserializeObject<List<Users>>(result);

            foreach (var user in usersList)
            {
                UsersList.Add(user);
            }
        }

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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
