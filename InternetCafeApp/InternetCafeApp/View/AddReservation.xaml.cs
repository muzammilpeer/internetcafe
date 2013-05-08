using InternetCafeApp.Controller;
using InternetCafeApp.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Threading;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace InternetCafeApp.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddReservation : Page
    {
        private DatabaseManager data = new DatabaseManagerImpl();
        private ViewModel _vm;

        public DateTime currentTime = DateTime.Now;
        public AddReservation()
        {
            this.InitializeComponent();
            _vm = new ViewModel(data);
            _vm.SelectedItemClient = new Client();
            _vm.SelectedItemRecord = new Record();
            _vm.SelectedItemRoom = new Room();

            _vm.InitializeForAddReservation();
            DataContext = _vm;
            txtCheckOut.Text = txtCheckIn.Text;

            comboxClientName.IsEnabled = true;
            txtName.IsEnabled = false;
            /*
            if (comboxClientName.Items.Count() > 0)
            {
              
            }
            else
            {
                comboxClientName.IsEnabled = false;
                txtName.IsEnabled = true;
            }
            */
            }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }
        private bool validateFields()
        {
            bool check = true;
            //Client Name Validation
            if (!comboxClientName.IsEnabled)
            {
                if (txtName.Text.Length < 1)
                    check = false;

            }  else {
                if (comboxClientName.SelectedIndex < 0)
                    check = false;
            }
            //Client Name Validation End
            //Check In/Out time cannot be the same.
            if (txtCheckIn.Text == txtCheckOut.Text)
                check = false;
            //Check In/Out time cannot be the same End.

            if (comboBoxRooms.SelectedIndex < 0)
                check = false;

            return check;
        }
        private DateTime getCheckOutTime(DateTime currentTime)
        {
            if (txtCheckOut.Text.ToString() == "Unlimited")
            {
                return Convert.ToDateTime("1/1/2020 12:00:00 AM");
            }
            return currentTime;
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (validateFields())
            {
                Record newRecord = new Record();
                Client newClient = new Client();
                bool successful = false;

                if (!comboxClientName.IsEnabled)
                {
                    newClient.oiclient = _vm.Clients.Count() + 1;
                    newClient.name = txtName.Text;
                    newClient.gender = tgGender.IsOn;
                    newClient.active = true;
                    newClient.modDate = DateTime.Now;
                    newClient.lastLogin = DateTime.Now;
                    _vm.AddClient(newClient);


                    newRecord.oiclient = newClient.oiclient;
                    newRecord.oiroom = _vm.SelectedItemRoom.oiroom;
                    newRecord.active = true;
                    newRecord.checkIn = Convert.ToDateTime(txtCheckIn.Text); // DateTime.TryParse(txtCheckIn.Text);
                    newRecord.checkOut = getCheckOutTime(Convert.ToDateTime(txtCheckOut.Text)); // DateTime.TryParse(txtCheckOut.Text);
                    newRecord.isCardReader = chkCardReader.IsChecked.ToString();
                    newRecord.isWebCam = chkWebCam.IsChecked.ToString();
                    newRecord.modDate = DateTime.Now;
                    newRecord.oirecord = _vm.Records.Count() + 1;
                    _vm.AddRecord(newRecord);
                    successful = true;
                }
                else
                {
                    newRecord.oiclient = _vm.SelectedItemClient.oiclient;
                    newRecord.oiroom = _vm.SelectedItemRoom.oiroom;
                    newRecord.active = true;
                    newRecord.checkIn = Convert.ToDateTime(txtCheckIn.Text); // DateTime.TryParse(txtCheckIn.Text);
                    newRecord.checkOut = getCheckOutTime(Convert.ToDateTime(txtCheckOut.Text)); // DateTime.TryParse(txtCheckOut.Text);
                    newRecord.isCardReader = chkCardReader.IsChecked.ToString();
                    newRecord.isWebCam = chkWebCam.IsChecked.ToString();
                    newRecord.modDate = DateTime.Now;
                    newRecord.oirecord = _vm.Records.Count() + 1;
                    _vm.AddRecord(newRecord);
                    successful = true;
                }
                if (successful)
                {
                    Room updateRoomAvailability = _vm.SelectedItemRoom;
                    updateRoomAvailability.isAvailable = false;
                    updateRoomAvailability.oirecord = _vm.Records.Count();
                    _vm.SelectedItemRoom = updateRoomAvailability;
                    _vm.UpdateRoom(updateRoomAvailability);
                    //Navigate to Home Screen.
                  //  this.Frame.Navigate(typeof(MainPage));
                    txtMessageBar.Text = "Room Reserved Successfully.";
                }
            }
            else {
                txtMessageBar.Text = "Please Fill Required Fields.";
            }


        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void comboBoxRooms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void comboxClientName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnAddName_Click(object sender, RoutedEventArgs e)
        {
            comboxClientName.IsEnabled = false;
            txtName.IsEnabled = true;
        }

        private void combCheckIn_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*
            DateTime checkoutTime = new DateTime();
            string text = (sender as ComboBox).SelectedItem.ToString();
            if (text != null)
            {
                int interval = Int32.Parse(text);
                checkoutTime.AddMinutes(interval);
                txtCheckOut.Text = checkoutTime.ToString();
            }*/
            //1/1/0001 12:00:00 AM
            ComboBoxItem item = (sender as ComboBox).SelectedItem as ComboBoxItem;

            if (item != null)
            {
                if (Int32.Parse(item.Tag.ToString()) != -1)
                {
                    DateTime checkoutTime = Convert.ToDateTime(txtCheckIn.Text);
                    txtCheckOut.Text = checkoutTime.AddMinutes(Int32.Parse(item.Tag.ToString())).ToString();
                }
                else {
                    txtCheckOut.Text = "Unlimited";
                }
                
//               _vm.SelectedItemRecord.checkOut  = checkoutTime.AddMinutes(Int32.Parse(item.Tag.ToString()));
            }
        }
    }
}
