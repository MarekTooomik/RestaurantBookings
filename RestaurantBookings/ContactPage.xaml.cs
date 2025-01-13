using Microsoft.Maui.Controls;

namespace RestaurantBookings
{
    public partial class ContactPage : ContentPage
    {
        public ContactPage()
        {
            InitializeComponent();
        }

        private async void OnBackToHomeClicked(object sender, EventArgs e)
        {
            // Navigate back to the main page
            await Navigation.PopAsync();
        }
    }
}