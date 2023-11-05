using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using static TravelPal.UserDetailsWindow;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for TravelsWindow.xaml
    /// </summary>
    public partial class TravelsWindow : Window
    {
        public TravelsWindow()
        {
            InitializeComponent();
            TravelsWindowMain.Content = new TravelsWindowPage1();
            string holdUsername = UserManager.CurrentlySignedInUser.Username;
            userNameHere.Text = $"User: {holdUsername}";
        }

        public class TravelManager
        {
            public static List<Travel> Travels { get; set; } = new()
            {
                new Travel("Lund.Sweden", "France", 2, "vacation"),
                new Travel("Bacelona.Spain", "Iceland", 1, "workTrip")
            };

            // + addTravel(Travel): void
            public static Travel? AddTravel(string departingFrom, string destination, int travellers, string travelType, bool allInclusive)
            {
                if (travelType == "vacation")
                {
                    Vacation vacation = new(departingFrom, destination, travellers, allInclusive);
                    Travels.Add(vacation);

                    return vacation;
                }
                else
                {


                    return null;
                }

            }
            // + removeTravel(Travel): void
        }
        public class Travel
        {
            // + destination: string
            public required string Destination { get; set; }
            // + country: Countries
            public required string DepartingFrom { get; set; }
            // + travellers: int
            public required int Travellers { get; set; }
            public required string TravelType { get; set; }


            // + Travel({Props})(virtual) + GetInfo(): string
            [SetsRequiredMembers]
            public Travel(string departingFrom, string destination, int travellers, string travelType)
            {
                DepartingFrom = departingFrom;
                Destination = destination;
                Travellers = travellers;
                TravelType = travelType;
            }
        }
        public class WorkTrip : Travel
        {
            public required string MeetingDetails { get; set; }

            // + Trip(meetingDetails)
            // + GetInfo(): string
            [SetsRequiredMembers]
            public WorkTrip(string departingFrom, string destination, int travellers, string travelType, string meetingDetails) : base(departingFrom, destination, travellers, travelType)
            {
                MeetingDetails = meetingDetails;
            }
        }
        public class Vacation : Travel
        {
            // + allInclusive: bool
            public required bool AllInclusive { get; set; }
            // + Vacation(allInclusive)
            // + GetInfo(): string
            [SetsRequiredMembers]

            public Vacation(string departingFrom, string destination, int travellers, string travelType, bool allInclusive) : base(departingFrom, destination, travellers, travelType)
            {
                AllInclusive = allInclusive;
            }
        }


        private void Button_Click_Travels(object sender, RoutedEventArgs e)
        {
            // Starting page för TravelsWindow
            TravelsWindowMain.Content = new TravelsWindowPage1();
        }
        private void Button_Click_AddTravels(object sender, RoutedEventArgs e)
        {
            // Add travels page
            TravelsWindowMain.Content = new AddTravelWindow();
        }
        private void Button_Click_TravelDetails(object sender, RoutedEventArgs e)
        {
            // Travel details page
            TravelsWindowMain.Content = new TravelsDetailsWindow();
        }

        private void Button_Click_LogOut(object sender, RoutedEventArgs e)
        {
            UserManager.UserSignOut();

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
