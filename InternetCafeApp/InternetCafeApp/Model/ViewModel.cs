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
    class ViewModel : INotifyPropertyChanged
    {
        DatabaseManager _data;

        public ViewModel(DatabaseManager data)
        {
            _data = data;
        }

        async public void Initialize()
        {
            Rooms = await _data.LoadRoom();
            Records = await _data.LoadRecord();
            Clients = await _data.LoadClient();
            RecordsInt = await _data.LoadRecordWithInt();
        }
        async public void InitializeForAddReservation()
        {
            Rooms = await _data.LoadRoomAvailable();
            Records = await _data.LoadRecord();
            Clients = await _data.LoadClient();
            RecordsInt = await _data.LoadRecordWithInt();
        }
        async public void InitializeRecordsInt()
        {
            RecordsInt = await _data.LoadRecordWithInt();
            SettingModels = await _data.LoadSettingModel();
        }
        async public  Task<ObservableCollection<SettingModel>> getSettingMod()
        {
             return await _data.LoadSettingModel();
        }
    

        private ObservableCollection<SettingModel> settingModels;
        public ObservableCollection<SettingModel> SettingModels
        {
            get { return settingModels; }
            set
            {
                settingModels = value;
                RaisePropertyChanged();
            }
        }
 


        private Room selectedItemRoom;
        public Room SelectedItemRoom
        {
            get { return this.selectedItemRoom; }
            set
            {
                if (value != selectedItemRoom)
                {
                    selectedItemRoom = value;
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

        async internal void UpdateRoomFilterRoomNo(int roomNo)
        {
            ObservableCollection<Room> filterR = await _data.LoadRoomFilterRoomNo(roomNo);
            if (filterR.Count() > 0)
            {
                Room rec = filterR.ElementAt(0);
                rec.isAvailable = true;
//                rec.oiclient = -1;
                await _data.UpdateRoom(rec);
                RaisePropertyChanged("Rooms");
            }
        }
        internal void DeleteRoom(Room cust)
        {
            _data.RemoveRoom(cust);
            RaisePropertyChanged("Rooms");
        }
        /*Record */
        private Record selectedItemRecord;
        public Record SelectedItemRecord
        {
            get { if (this.selectedItemRecord.checkIn.ToString().Equals("1/1/0001 12:00:00 AM")) { this.selectedItemRecord.checkIn = DateTime.Now; }
                return this.selectedItemRecord; }
            set
            {
                if (value != selectedItemRecord)
                {
                    selectedItemRecord = value;
                    RaisePropertyChanged();
                }
            }
        }

        private ObservableCollection<Record> records;
        public ObservableCollection<Record> Records
        {
            get { return records; }
            set
            {
                records = value;
                RaisePropertyChanged();
            }
        }

        internal void AddRecord(Record cust)
        {
            _data.AddRecord(cust);
            RaisePropertyChanged("Record");
        }
        internal void UpdateRecord(Record cust)
        {
            _data.UpdateRecord(cust);
            RaisePropertyChanged("Record");
        }
        async internal void UpdateRecordnRoomPaymentDone(int oiRecord,int totalAmt, int recievedAmt)
        {
            Record newRecord = await _data.LoadRecordwithOiRecord(oiRecord);
            Room newRoom = await _data.LoadRoomwithOiRoom(newRecord.oiroom);
            newRecord.totalAmount = totalAmt;
            newRecord.recievedAmount = recievedAmt;

            newRoom.isAvailable = true;
            newRoom.oirecord = -1;

            await _data.UpdateRecord(newRecord);
            await _data.UpdateRoom(newRoom);
    }


        internal void DeleteRecord(Record cust)
        {
            _data.RemoveRecord(cust);
            RaisePropertyChanged("Record");
        }
        /*Record Int */
        private ObservableCollection<RecordInt> recordsint;
        public ObservableCollection<RecordInt> RecordsInt
        {
            get { return recordsint; }
            set
            {
                recordsint = value;
                RaisePropertyChanged();
            }
        }
        private RecordInt selectedItemRecordInt;
        public RecordInt SelectedItemRecordInt
        {
            get { return this.selectedItemRecordInt; }
            set
            {
                if (value != selectedItemRecordInt)
                {
                    selectedItemRecordInt = value;
                    RaisePropertyChanged();
                }
            }
        }

        /*Client*/
        private Client selectedItemClient;
        public Client SelectedItemClient
        {
            get { return this.selectedItemClient; }
            set
            {
                if (value != selectedItemClient)
                {
                    selectedItemClient = value;
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

        internal void AddClient(Client cust)
        {
            _data.AddClient(cust);
            RaisePropertyChanged("Client");
        }
        internal void UpdateClient(Client cust)
        {
            _data.UpdateClient(cust);
            RaisePropertyChanged("Client");
        }

        internal void DeleteClient(Client cust)
        {
            _data.RemoveClient(cust);
            RaisePropertyChanged("Client");
        }
        /*End Client*/

        /*Propery Changed Event Handler*/
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
