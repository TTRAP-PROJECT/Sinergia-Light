using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using firstMobileApp.Class;
using Newtonsoft.Json;

namespace firstMobileApp.Models
{
    internal class UserModel : INotifyPropertyChanged
    {
        API api;
        private Users _user;
        private string email;


        public UserModel()
        {
            api = new API();
            email = UserSessionManager.Email;
            
        }

        public async Task LoadData()
        {
            var result = await api.GetPostData($"/user/find/{email}");
            User = JsonConvert.DeserializeObject<Users>(result);
            
        }

        public Users User
        {
            get { return _user; }
            set
            {
                if (_user != value)
                {
                    _user = value;
                    OnPropertyChanged(nameof(User));
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
