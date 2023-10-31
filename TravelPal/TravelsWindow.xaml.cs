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
        }

        interface PackingListItem
        {
            // + name: string

            // + GetInfo(): string
        }
        new class TravelDocument : PackingListItem
        {
            // + required: bool

            // + Document(name, required)
            // + GetInfo(): string
        }
        new class OtherItem : PackingListItem
        {
            // + quantity: int

            // + Other(name, quantity)
            // + GetInfo(): string
        }

        private new class TravelManager
        {
            // + travels: List<Travel>

            // + addTravel(Travel): void
            // + removeTravel(Travel): void
        }
        private new class Travel
        {
            // + destination: string
            // + country: Countries
            // + travellers: int
            // + packingList: List<PackingListItem>
            // + startDate: DateTime
            // + endDate: DateTime
            // + travelDays: int

            // + Travel({Props})(virtual) + GetInfo(): string
            // - calculateTravelDays(): int
        }
        private new class WorkTrip
        {
            // + meetingDetails: string

            // + Trip(meetingDetails)
            // + GetInfo(): string
        }
        private new class Vacation
        {
            // + allInclusive: bool

            // + Vacation(allInclusive)
            // + GetInfo(): string
        }
    }
}
