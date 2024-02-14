using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.PlatformConfiguration.GTKSpecific;

namespace LocationFInderApp.Views
{
    public partial class MainPage : ContentPage
    {
        public ICommand TrackLocationCommand { get; private set; }
        public Position MapPosition { get; set; }
        public MainPage()
        {
            InitializeComponent();
            //googleMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(24.000380, 89.249990), Distance.FromMiles(1)));
            TrackLocationCommand = new Command(async () => await TrackLocationAsync());
            BindingContext = this;

            // Optionally add a pin programmatically
            Pin pinTokyo = new Pin()
            {
                Position = new Position(24.000380, 89.249990),
                Label = "Marker Label",
                Address = "Marker Address",
                Type = PinType.Place,
               
            };
          

            MapPosition = new Position(24.000380, 89.249990);

        }
        private async Task TrackLocationAsync()
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    // Update map
                    //mapView.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(location.Latitude, location.Longitude), Distance.FromMiles(1)));

                    // Display location details
                    locationLabel.Text = $"Location: {location.Latitude}, {location.Longitude}";
                }
                else
                {
                    locationLabel.Text = "Unable to get location.";
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., no location permission)
                locationLabel.Text = $"Error: {ex.Message}";
            }
        }
    }
}
