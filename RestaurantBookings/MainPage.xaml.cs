using System.Collections.ObjectModel;

namespace RestaurantBookings
{
    public partial class MainPage : ContentPage
    {
        public DateTime SelectedDate { get; set; }
        public int SelectedTimeIndex { get; set; }
        public List<string> TimeOptions { get; set; }

        public MainPage()
        {
            InitializeComponent();

            // Initialize properties
            SelectedDate = DateTime.Now.Date;
            SelectedTimeIndex = 0;

            // Generate available time options in 30-minute intervals from 08:00 to 22:00
            TimeOptions = GenerateTimeOptions();

            // Bind the page's context to itself
            this.BindingContext = this;
        }

        // Generate the list of time options in 30-minute intervals
        private List<string> GenerateTimeOptions()
        {
            List<string> options = new List<string>();
            DateTime startTime = DateTime.Today.AddHours(8);
            DateTime endTime = DateTime.Today.AddHours(22);

            while (startTime <= endTime)
            {
                options.Add(startTime.ToString("HH:mm"));
                startTime = startTime.AddMinutes(30);
            }

            return options;
        }

        private void OnDateChanged(object sender, DateChangedEventArgs e)
        {
            SelectedDate = e.NewDate; // Update the SelectedDate property when the user picks a date
        }

        private async void OnBookClicked(object sender, EventArgs e)
        {
            // Get the selected time
            string selectedTime = TimeOptions[SelectedTimeIndex];

            // Display a confirmation alert
            await DisplayAlert(
                "Booking Confirmed",
                $"Your booking for {SelectedDate.ToShortDateString()} at {selectedTime} is confirmed.",
                "OK"
            );

            // Navigate to the PersonalBookingPage with booking details
            await Navigation.PushAsync(new PersonalBookingPage(
                SelectedDate.ToShortDateString(),
                selectedTime
            ));
        }
        private async void OnViewBookingsClicked(object sender, EventArgs e)
        {
            // Navigate to the PersonalBookingPage to view bookings
            await Navigation.PushAsync(new PersonalBookingPage(
                SelectedDate.ToShortDateString(),
                TimeOptions[SelectedTimeIndex]
            ));
        }

    }
}
