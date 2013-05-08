using InternetCafeApp.Controller;
using InternetCafeApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace InternetCafeApp.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddPayment : Page
    {
        private DatabaseManager data = new DatabaseManagerImpl();
        private ViewModel _vm;
        int halfhour;
        int firstHour;
        int secondHour;

        public AddPayment()
        {
            this.InitializeComponent();
            _vm = new ViewModel(data);
            _vm.InitializeRecordsInt();
            DataContext = _vm;

           // txtCheckOut.Text = DateTime.Now.ToString();
            txtRecievedAmount.Text = "0.0";
            txtTotalAmount.Text = "0.0";
            loadValues();
        }

        async private Task loadValues()
        {
            if (await _vm.getSettingMod() != null)
            {
                ObservableCollection<SettingModel> dataSet = await _vm.getSettingMod();

                int count = dataSet.Count();
                for(int i=0;i<count; i ++)
                {
                    SettingModel val = dataSet.ElementAt(i);
                    if (val.key == "halfhour")
                    {
                        halfhour = Int32.Parse(val.value);
                    }else if (val.key == "firsthour") 
                    {
                        firstHour = Int32.Parse(val.value);
                    }else if (val.key == "secondhour")
                    {
                        secondHour = Int32.Parse(val.value);
                    }
                }
            }
        }


        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void btnAddName_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (_vm.SelectedItemRecordInt != null)
            {
                _vm.UpdateRecordnRoomPaymentDone(_vm.SelectedItemRecordInt.oirecord, Int32.Parse(txtTotalAmount.Text), Int32.Parse(txtRecievedAmount.Text));
                _vm.RecordsInt.RemoveAt(comboBoxRooms.SelectedIndex);
                txtCheckOut.Text = "";
                txtCheckIn.Text = "";
                txtTotalAmount.Text = "";
                txtTotalTime.Text = "";
                txtRecievedAmount.Text = "";
                txtMessageBar.Text = "Payment Save Successfully";
            }

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }

        private void comboxClientName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private double calculateTotalAmount(String checkIn, String checkOut)
        {
            DateTime checkInTime = Convert.ToDateTime(checkIn);
            DateTime checkOutTime = Convert.ToDateTime(checkOut);
            TimeSpan totalTimeExpended = checkOutTime.Subtract(checkInTime);
            txtTotalTime.Text = "Total Time :" + totalTimeExpended.TotalHours.ToString();
            Double totalAmount = 0;
           if (totalTimeExpended.TotalMinutes > 60)
            {
                int hours = Convert.ToInt32(totalTimeExpended.TotalHours);
                totalAmount = hours * secondHour;
                totalAmount = totalAmount - secondHour;
                totalAmount = totalAmount + firstHour;
           }
           else if (totalTimeExpended.TotalMinutes <= 60 && totalTimeExpended.TotalMinutes > 30 )
            {
                totalAmount = firstHour; 
           } else if (totalTimeExpended.TotalMinutes <= 30)
            {
                totalAmount = halfhour;
            }
            return totalAmount;
        }

        private void comboBoxRooms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtCheckOut.Text = DateTime.Now.ToString();
            if(txtCheckIn.Text.Length >  0 && txtCheckOut.Text.Length > 0)
            txtTotalAmount.Text = (calculateTotalAmount(txtCheckIn.Text, txtCheckOut.Text)).ToString();

        }

      

        private void btnRefreshValue_Click(object sender, RoutedEventArgs e)
        {
            loadValues();
        }

    }
}
