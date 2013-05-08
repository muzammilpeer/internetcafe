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
    public class RoomViewModel : INotifyPropertyChanged
    {
        DatabaseManager _data;

        public RoomViewModel(DatabaseManager data)
        {
            _data = data;
        }

        async public void Initialize()
        {
            Rooms = await _data.LoadRoom();
        }

        private Room selectedItem;
        public Room SelectedItem
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

        private ObservableCollection<Room> rooms;
        public ObservableCollection<Room> Rooms
        {
            get { return rooms; }
            set
            {
                rooms = value;
                RaisePropertyChanged();
            }
        }

        internal void AddRoom(Room cust)
        {
            _data.AddRoom(cust);
            RaisePropertyChanged("Rooms");
        }
        internal void UpdateRoom(Room cust)
        {
            _data.UpdateRoom(cust);
            RaisePropertyChanged("Rooms");
        }

        internal void DeleteRoom(Room cust)
        {
            _data.RemoveRoom(cust);
            RaisePropertyChanged("Rooms");
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
