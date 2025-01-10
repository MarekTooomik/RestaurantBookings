namespace RestaurantBookings
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new NavigationPage(new MainPage())); // Ensure MainPage is wrapped in NavigationPage
        }
    }
}