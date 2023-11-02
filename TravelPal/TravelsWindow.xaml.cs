using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Windows;

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
        }

        public class TravelManager
        {
            public static List<Travel> travel { get; set; } = new();

            // + addTravel(Travel): void
            // + removeTravel(Travel): void
        }
        public class Travel
        {
            // + destination: string
            public required string Destination { get; set; }
            // + country: Countries
            // + travellers: int
            public required int Travellers { get; set; }
            // + packingList: List<PackingListItem>
            // + startDate: DateTime
            public required DateTime StartDate { get; set; }
            // + endDate: DateTime
            public required DateTime EndDate { get; set; }
            // + travelDays: int
            public required int TravelDays { get; set; }

            // + Travel({Props})(virtual) + GetInfo(): string
            // - calculateTravelDays(): int
            [SetsRequiredMembers]
            public Travel(string destination, int travellers, DateTime startDate, DateTime endDate, int travelDays)
            {
                Destination = destination;
                Travellers = travellers;
                StartDate = startDate;
                EndDate = endDate;
                TravelDays = travelDays;
            }
        }
        public class WorkTrip : Travel
        {
            // + meetingDetails: string
            public required string MeetingDetails { get; set; }

            // + Trip(meetingDetails)
            // + GetInfo(): string
            [SetsRequiredMembers]
            public WorkTrip(string destination, int travellers, DateTime startDate, DateTime endDate, int travelDays, string meetingDetails) : base(destination, travellers, startDate, endDate, travelDays)
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

            public Vacation(string destination, int travellers, DateTime startDate, DateTime endDate, int travelDays, bool allInclusive) : base(destination, travellers, startDate, endDate, travelDays)
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

    }
}
