//Prabakaran.A
//MS Software Engineering (2011-2016)
//VIT University - Chennai Campus
//Tamilnadu State
//India - 600 048
//www.facebook.com/prabakaran1993
using System;
using System.Collections.Generic;
using System.IO; //for specify path -> namespace
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
using Windows.Storage;
using SQLite; // for sqlite namespace
using System.Diagnostics;
using System.ComponentModel;
using Windows.UI.Popups; //for message dialog -> namespace

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace InternetCafeApp.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SqliteSample : Page
    {
        public SqliteSample()
        {
            this.InitializeComponent();
        }

       

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        public class person
        {

            [MaxLength(5), PrimaryKey]
           
            public String name { get; set; }
            [MaxLength(255)]
            public String address { get; set; }
            [MaxLength(11)]
            public Double phone { get; set; }
        }

        private async void createtable(object sender, RoutedEventArgs e)
        {
            try
            {
                var dbpath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "data.db3");
                using (var db = new SQLite.SQLiteConnection(dbpath))
                {
                    // Create the tables if they don't exist
                    db.CreateTable<person>();
                    db.Commit();

                    db.Dispose();
                    db.Close();
                }
                var line = new MessageDialog("Table Created");
                await line.ShowAsync();
            }
            catch
            {

            }
        }

        private async void insert(object sender, RoutedEventArgs e)
        {
            try
            {

                if (txt1.Text != "" && txt2.Text != "" && txt3.Text != "")
                {
                    var dbpath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "data.db3");
                    using (var db = new SQLite.SQLiteConnection(dbpath))
                    {
                        // Create the tables if they don't exist
                        db.Insert(new person()
                        {

                            name = txt1.Text.ToString(),
                            address = txt2.Text.ToString(),
                            phone = Convert.ToDouble(txt3.Text.ToString()),
                        }
                        );


                        db.Commit();
                        db.Dispose();
                        db.Close();
                        var line = new MessageDialog("Records Inserted");
                        await line.ShowAsync();
                    }
                }
                else
                {
                    throw new NullReferenceException("Enter The Data In Textboxes");
                    //var line = new MessageDialog("Enter The Data In Textboxes");
                    //await line.ShowAsync();
                }

                           }
            catch(SQLiteException )
            {
                
            }
            catch (NullReferenceException ex)
            {
                list1.Items.Add(ex.Message);
            }
        }

        private async void deleteall(object sender, RoutedEventArgs e)
        {
            var dbpath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "data.db3");
            using (var db = new SQLite.SQLiteConnection(dbpath))
            {
                db.DeleteAll<person>();

            }
            var line = new MessageDialog("All Records Deleted");
            await line.ShowAsync();
        }

        private async void listtable(object sender, RoutedEventArgs e)
        {
            try
            {
                var dbpath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "data.db3");
                using (var db = new SQLite.SQLiteConnection(dbpath))
                {
                    var d = from x in db.Table<person>() select x;
                    list1.Items.Clear();
                    foreach (var sd in d)
                    {
                        
                        list1.Items.Add(sd.name.ToString());
                        //list1.Items.Add(sd.address.ToString());
                        //list1.Items.Add(sd.phone.ToString());
                    }
                    db.Dispose();
                    db.Close();
                }
                var line = new MessageDialog("All Records Listed");
                await line.ShowAsync();
            }
            catch
            {
            }
        }

        private async void drop(object sender, RoutedEventArgs e)
        {
            try
            {
                var dbpath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "data.db3");
                using (var db = new SQLite.SQLiteConnection(dbpath))
                {
                    db.DropTable<person>();
                    db.Dispose();
                    db.Close();

                }
                var line = new MessageDialog("Table Dropped");
                await line.ShowAsync();
            }
            catch
            {
            }
        }

        private void ListView_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                txt1.Text = list1.SelectedItem.ToString();

            }
            catch
            {
            }

        }



        private async void deleteselected(object sender, RoutedEventArgs e)
        {
          

            try
            {
                var dbpath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "data.db3");
                using (var db = new SQLite.SQLiteConnection(dbpath))
                {
                    db.Delete<person>(list1.SelectedItem.ToString());

                    var d = from x in db.Table<person>() select x;
                    list1.Items.Clear();
                    foreach (var sd in d)
                    {
                        list1.Items.Add(sd.name.ToString());
                        //list1.Items.Add(sd.address.ToString());
                        //list1.Items.Add(sd.phone.ToString());
                    }
                    db.Dispose();
                    db.Close();
                }
                var line = new MessageDialog("Selected Item Deleted");
                await line.ShowAsync();
            }
            catch
            {
            }

        }

        private void LayoutRoot_KeyDown(object sender, KeyRoutedEventArgs e)
        {

        }

        private void txt2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txt1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        //Prabakaran.A
        //MS Software Engineering (2011-2016)
        //VIT University - Chennai Campus
        //Tamilnadu State
        //India - 600 048
        //www.facebook.com/prabakaran1993
     
    }
}
