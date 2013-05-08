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
using Callisto.Controls;
using WinRTXamlToolkit.Controls;
using Windows.UI.Popups;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace InternetCafeApp.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MaintainRoom : Page
    {
        private DatabaseManager data = new DatabaseManagerImpl();
        private ViewModel _vm;

        public MaintainRoom()
        {
            this.InitializeComponent();
            _vm = new ViewModel(data);
            _vm.Initialize();
            DataContext = _vm;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
        private bool isEmptyFields()
        {
            return false;
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (Int32.Parse(txtRoomNo.Text) == _vm.Rooms.Count()+1)
            {
                Room newRoom = new Room();
                newRoom.oiroom = _vm.Rooms.Count() + 1;
                newRoom.modDate = DateTime.Now;
                newRoom.roomNo = Int32.Parse(txtRoomNo.Text);
                newRoom.ipaddress = txtIpAddress.Text;
                newRoom.isAvailable = true;
                newRoom.remarks = txtRemarks.Text;
                newRoom.computerDescription = txtComputerDesc.Text;
                newRoom.modDate = DateTime.Now;
                newRoom.active = (bool)chkActive.IsChecked;
                _vm.AddRoom(newRoom);
                txtMessageBar.Text = "New Room Added in Database Successfully.";
                comboBoxRooms.IsEnabled = true;
                _vm.Initialize();
                _vm.SelectedItemRoom = newRoom;
/*                comboBoxRooms.SelectedIndex = _vm.Rooms.Count()-1;*/
            }
            else
            {
                _vm.SelectedItemRoom.modDate = DateTime.Now;
                _vm.UpdateRoom(_vm.SelectedItemRoom);
                txtMessageBar.Text = "Updated Room Database Successfully.";
            }
            comboBoxRooms.SelectedItem = _vm.SelectedItemRoom;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }

        private void comboBoxRooms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtMessageBar.Text = "No Message Yet";
/*            Room selectedIt = _vm.SelectedItem;

            txtRoomNo.Text = _vm.SelectedItem.roomNo.ToString();*/
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }
        private void CommandInvokedHandler(IUICommand command)
        {
            // Do something here on the command handler
            IUICommand com = command;
            if ((_vm.SelectedItemRoom != null) && command.Label.Equals("OK"))
            {
                _vm.DeleteRoom(_vm.SelectedItemRoom);
                _vm.Initialize();
            }
        }
        private async void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            // Create a MessageDialog
            var messageDialog = new MessageDialog("Hello Windows Store App.");
            // Or create a separate callback for different commands

            messageDialog.Commands.Add(new UICommand(
                "OK", new UICommandInvokedHandler(this.CommandInvokedHandler)));
            messageDialog.Commands.Add(new UICommand(
                "Close", new UICommandInvokedHandler(this.CommandInvokedHandler)));

            // Set CommandIndex. 0 means default.
            messageDialog.DefaultCommandIndex = 0;
            messageDialog.CancelCommandIndex = 1;

            // Show MessageDialog
            await messageDialog.ShowAsync();

            /*
            if ((_vm.SelectedItemRoom.oiroom != 0) && (Int32.Parse(txtRoomNo.Text) != (_vm.Rooms.Count() + 1)))
            {
                _vm.DeleteRoom(_vm.SelectedItemRoom);
            }
             * */
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            comboBoxRooms.IsEnabled = false;
            txtRoomNo.Text = (_vm.Rooms.Count() + 1).ToString();
            txtComputerDesc.Text = "";
            txtIpAddress.Text = "";
            txtRemarks.Text = "";
            chkActive.IsChecked = false;
            chkCardReader.IsChecked = false;
            txtModDate.Text = DateTime.Now.ToString();
          //  Room newRoom = new Room();
           // newRoom.oiroom = _vm.Rooms.Count() + 1;
//            newRoom.modDate = DateTime.Now;
           // _vm.SelectedItemRoom = newRoom;
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {

        }
       
    }
}
