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
    class RecordViewModel : INotifyPropertyChanged
    {
        DatabaseManager _data;

        public RecordViewModel(DatabaseManager data)
        {
            _data = data;
        }

        async public void Initialize()
        {
            Records = await _data.LoadRecord();
        }

        private Record selectedItem;
        public Record SelectedItem
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

        internal void AddRoom(Record cust)
        {
            _data.AddRecord(cust);
            RaisePropertyChanged("Record");
        }
        internal void UpdateRoom(Record cust)
        {
            _data.UpdateRecord(cust);
            RaisePropertyChanged("Record");
        }

        internal void DeleteRoom(Record cust)
        {
            _data.RemoveRecord(cust);
            RaisePropertyChanged("Record");
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
