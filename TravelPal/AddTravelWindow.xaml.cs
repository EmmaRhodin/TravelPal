﻿using System;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using static TravelPal.TravelsWindow;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for AddTravelWindow.xaml
    /// </summary>
    public partial class AddTravelWindow : Page
    {

        public AddTravelWindow()
        {
            InitializeComponent();
            cbxTravelType.Items.Add("Work Trip");
            cbxTravelType.Items.Add("Vacation");
            foreach (Countries.EuropeanCountry country in (Countries.EuropeanCountry[])Enum.GetValues(typeof(Countries.EuropeanCountry)))
            {
                cbxDestination.Items.Add(country);
            }
            foreach (Countries.Country country in (Countries.Country[])Enum.GetValues(typeof(Countries.Country)))
            {
                cbxDestination.Items.Add(country);
            }
        }

        private void btnSaveTravel_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            bool allInclusive = false;
            string meetingDetails = "";
            string travelType = "";

            bool getCity = false;
            bool getCountry = false;
            bool getPassenger = false;
            bool getTravelType = false;
            bool getDestination = false;

            if (tbxDepartureCity.Text.Length < 1 || tbxDepartureCity.Text == "City")
            {
                txtDepartingError.Text = "Enter City";
                getCity = false;
            }
            else if (!Regex.IsMatch(tbxDepartureCity.Text, @"^[a-öA-Ö]+$"))
            {
                txtDepartingError.Text = "Invalid City";
                getCity = false;
            }
            else
            {
                txtDepartingError.Text = "";
                getCity = true;
            }

            if (tbxDepartureCountry.Text.Length < 1 || tbxDepartureCountry.Text == "Country")
            {
                if (txtDepartingError.Text == "")
                {
                    txtDepartingError.Text = "Enter Country";
                }
                getCountry = false;
            }
            else if (!Regex.IsMatch(tbxDepartureCountry.Text, @"^[a-öA-Ö]+$"))
            {
                if (txtDepartingError.Text == "")
                {
                    txtDepartingError.Text = "Invalid Country";
                }
                getCountry = false;
            }
            else
            {
                txtDepartingError.Text = "";
                getCountry = true;
            }

            if (tbxPassengerNumber.Text.Length < 1)
            {
                txtPassengerError.Text = "Enter amount";
                getPassenger = false;
            }
            else if (!Regex.IsMatch(tbxPassengerNumber.Text, @"^[0-9]+$") || tbxPassengerNumber.Text == "0" || tbxPassengerNumber.Text.StartsWith("0"))
            {
                txtPassengerError.Text = "Invalid";
                getPassenger = false;
            }
            else
            {
                txtPassengerError.Text = "";
                getPassenger = true;
            }

            if (cbxTravelType.SelectedIndex < 0)
            {
                txtTypeOfTripError.Text = "Select Travel Type";
                getTravelType = false;
            }
            else if (cbxTravelType.SelectedIndex >= 0)
            {


                if (cbxTravelType.SelectedIndex == 0)
                {
                    if (ckbxAllInclusive.IsChecked == true)
                    {
                        txtTypeOfTripError.Text = "Worktrip can't be all inclusive";
                        getTravelType = true;
                    }
                    else
                    {
                        txtTypeOfTripError.Text = "";
                        getTravelType = true;

                        travelType = "workTrip";
                        meetingDetails = tbxMeetingDetails.Text;
                    }
                }
                else if (cbxTravelType.SelectedIndex == 1)
                {
                    if (tbxMeetingDetails.Text != "")
                    {
                        txtTypeOfTripError.Text = "Can't have meeting details on vacation";
                        getTravelType = false;
                    }
                    else
                    {
                        travelType = "vacation";
                        getTravelType = true;
                        if (ckbxAllInclusive.IsChecked == true)
                        {
                            allInclusive = true;
                        }
                        else
                        {
                            allInclusive = false;
                        }
                    }
                }
            }
            else if (cbxTravelType.SelectedIndex == 1)
            {
                txtTypeOfTripError.Text = "";
                getTravelType = true;
            }

            if (cbxDestination.SelectedIndex < 0)
            {
                txtDestinationError.Text = "Enter Destination";
                getDestination = false;
            }
            else
            {
                txtDestinationError.Text = "";
                getDestination = true;
            }

            if (getCity == true && getCountry == true && getPassenger == true && getTravelType == true && getDestination == true)
            {
                string city = tbxDepartureCity.Text;
                string country = tbxDepartureCountry.Text;
                string departure = city + "." + country;
                string passengers = tbxPassengerNumber.Text;
                int passengersInt = Convert.ToInt32(passengers);
                string destination = cbxDestination.Text;

                TravelManager.AddTravel(departure, destination, passengersInt, travelType, allInclusive, meetingDetails);
            }
        }
    }
}
