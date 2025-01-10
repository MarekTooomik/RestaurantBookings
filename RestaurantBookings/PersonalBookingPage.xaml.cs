using Microsoft.Maui.Controls;

namespace RestaurantBookings
{
    public partial class PersonalBookingPage : ContentPage
    {
        private string v;
        private string selectedTime;

        public PersonalBookingPage(string v = null, string selectedTime = null)
        {
            InitializeComponent();
            BookingDateLabel.Text = v ?? "No booking made.";
            BookingTimeLabel.Text = selectedTime ?? string.Empty;

            // Retrieve booking details from MainPage
            var mainPage = Application.Current.MainPage as NavigationPage;
            var mainPageContent = mainPage?.RootPage as MainPage;

            if (mainPageContent != null &&
                !string.IsNullOrEmpty(mainPageContent.SelectedDate.ToShortDateString()) &&
                mainPageContent.SelectedTimeIndex >= 0)
            {
                string selectedDate = mainPageContent.SelectedDate.ToShortDateString();
                string selectedTime = mainPageContent.TimeOptions[mainPageContent.SelectedTimeIndex];

                BookingDateLabel.Text = selectedDate;
                BookingTimeLabel.Text = selectedTime;
            }
            else
            {
                BookingDateLabel.Text = "No booking made.";
                BookingTimeLabel.Text = string.Empty;
            }
        }

        public PersonalBookingPage(string v, string selectedTime)
        {
            this.v = v;
            this.selectedTime = selectedTime;
        }

        private async void OnCancelBookingClicked(object sender, EventArgs e)
        {
            // Retrieve booking details from MainPage
            var mainPage = Application.Current.MainPage as NavigationPage;
            var mainPageContent = mainPage?.RootPage as MainPage;

            if (mainPageContent != null)
            {
                // Clear the booking details
                mainPageContent.SelectedDate = DateTime.MinValue;
                mainPageContent.SelectedTimeIndex = -1;

                // Update the labels to reflect no active bookings
                BookingDateLabel.Text = "No booking made.";
                BookingTimeLabel.Text = string.Empty;

                await DisplayAlert("Booking Cancelled", "Your booking has been successfully cancelled.", "OK");
            }
        }

        private async void OnBackToHomeClicked(object sender, EventArgs e)
        {
            // Navigate back to the main page
            await Navigation.PopAsync();
        }
    }
}
