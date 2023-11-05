using System.Windows.Controls;
using static TravelPal.TravelsWindow;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for TravelsWindowPage1.xaml
    /// </summary>
    public partial class TravelsWindowPage1 : Page
    {
        public TravelsWindowPage1()
        {
            InitializeComponent();

            foreach (Travel travel in TravelManager.Travels)
            {
                ListViewItem item = new ListViewItem();

                item.Content = "Ticket to: " + travel.Destination;
                lstbxBookedTravels.Items.Add(item);
            }
        }
        private void btnDelete_Click_Delete(object sender, System.Windows.RoutedEventArgs e)
        {
            ListBoxItem selectedItem = (ListBoxItem)lstbxBookedTravels.SelectedItem;
            if (selectedItem != null)
            {
                lstbxBookedTravels.Items.Remove(selectedItem);
            }
            else
            {
                // error message
            }
        }
    }
}
