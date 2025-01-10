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
            SelectedDate = DateTime.Now.Date;  
            SelectedTimeIndex = 0; 
            // Generate available time options in 30-minute intervals from 08:00 to 22:00
            TimeOptions = GenerateTimeOptions();
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
            SelectedDate = e.NewDate; 
        }
        private async void OnBookClicked(object sender, EventArgs e)
        {
            // Get the selected time from your TimeOptions array (or picker)
            string selectedTime = TimeOptions[SelectedTimeIndex];

            // Display a confirmation alert
            await DisplayAlert("Booking Confirmed",
                $"Your booking for {SelectedDate.ToShortDateString()} at {selectedTime} is confirmed.",
                "OK");

            // Navigate to the PersonalBookingPage and pass the booking details
            string selectedDate = DatePicker.Date.ToString("d");
            await Navigation.PushAsync(new PersonalBookingPage(selectedDate, selectedTime));

        }


    }
}
