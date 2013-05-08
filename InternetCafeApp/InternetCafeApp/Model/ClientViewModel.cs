using InternetCafeApp.Controller;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace InternetCafeApp.Model
{
    class ClientViewModel: INotifyPropertyChanged
    {
        DatabaseManager _data;

        public ClientViewModel(DatabaseManager data)
        {
            _data = data;
        }

        async public void Initialize()
        {
            Clients = await _data.LoadClient();
        }

        private Client selectedItem;
        public Client SelectedItem
        {
            get { return this.selectedItem; }
            set
            {
                if (value != selectedItem)
                {
                    selectedItem = value;
                    RaisePropertyChanged();
                }
            }
        }

        private ObservableCollection<Client> clients;
        public ObservableCollection<Client> Clients
        {
            get { return clients; }
            set
            {
                clients = value;
                RaisePropertyChanged();
            }
        }

        internal void AddRoom(Client cust)
        {
            _data.AddClient(cust);
            RaisePropertyChanged("Client");
        }
        internal void UpdateRoom(Client cust)
        {
            _data.UpdateClient(cust);
            RaisePropertyChanged("Client");
        }

        internal void DeleteRoom(Client cust)
        {
            _data.RemoveClient(cust);
            RaisePropertyChanged("Client");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(
            [CallerMemberName] string caller = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(
                   this, new PropertyChangedEventArgs(caller));
            }
        }
    }
}
