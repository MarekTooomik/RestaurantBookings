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
            SelectedDate = e.NewDate; 
        }

        private async void OnBookClicked(object sender, EventArgs e)
        {
            
            if (SelectedTimeIndex < 0 || SelectedTimeIndex >= TimeOptions.Count)
            {
                await DisplayAlert("Error", "Invalid time selection.", "OK");
                return;
            }

            string selectedTime = TimeOptions[SelectedTimeIndex];


            await DisplayAlert(
                "Booking Confirmed",
                $"Your booking for {SelectedDate.ToShortDateString()} at {selectedTime} is confirmed.",
                "OK"
            );

            try
            {
                // Navigate to the PersonalBookingPage with booking details
                await Navigation.PushAsync(new PersonalBookingPage(
                    SelectedDate.ToShortDateString(),
                    selectedTime
                ));
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"An error occurred while navigating: {ex.Message}", "OK");
            }
        }

        private async void OnViewBookingsClicked(object sender, EventArgs e)
        {
            try
            {
                // Validate SelectedTimeIndex
                if (SelectedTimeIndex < 0 || SelectedTimeIndex >= TimeOptions.Count)
                {
                    await DisplayAlert("Error", "Invalid time selection.", "OK");
                    return;
                }

                await Navigation.PushAsync(new PersonalBookingPage(
                    SelectedDate.ToShortDateString(),
                    TimeOptions[SelectedTimeIndex]
                ));
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private async void OnContactUsClicked(object sender, EventArgs e)
        {
            // Navigate to the ContactPage
            await Navigation.PushAsync(new ContactPage());
        }
    }
}