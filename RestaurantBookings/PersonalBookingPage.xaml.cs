using Microsoft.Maui.Controls;

namespace RestaurantBookings
{
    public partial class PersonalBookingPage : ContentPage
    {
        public PersonalBookingPage(string bookingDate, string bookingTime)
        {
            InitializeComponent();

            // Set the booking details to the labels
            BookingDateLabel.Text = bookingDate;
            BookingTimeLabel.Text = bookingTime;
        }

        private async void OnBackToHomeClicked(object sender, EventArgs e)
        {
            // Navigate back to the main page
            await Navigation.PopAsync();
        }
    }
}