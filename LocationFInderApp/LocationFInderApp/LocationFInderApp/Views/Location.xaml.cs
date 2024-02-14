using LocationFInderApp.Data;
using LocationFInderApp.Models;
using LocationFInderApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LocationFInderApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Location : ContentPage
	{
        private readonly LocationService _locationService;
        public Location ()
		{
			InitializeComponent ();
            _locationService = new LocationService();
        }

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    base.OnAppearing();


        //    // Start the timer when the page appears
        //    Device.StartTimer(TimeSpan.FromMinutes(1), () =>
        //    {
        //        // Call your function here
        //        OnTrackLocationClicked(null, null);

        //        // Return true to keep the timer running; return false to stop the timer
        //        return true;
        //    });
        //}


        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                var uri = new Uri(Constants.BaseAddress + "/Location");
                var modelResponse = await RestUtil<List<LocationView>, LocationView>.Get(uri);

                if (modelResponse != null && modelResponse.Data != null)
                {
                    locationListView.ItemsSource = modelResponse.Data;
                }
                else
                {
                    DisplayAlert("Error", "Failed to fetch location data.", "OK");
                }

                Device.StartTimer(TimeSpan.FromMinutes(1), () =>
                {
                    // Call your function here
                    CheckAndRequestLocationPermission();

                    // Return true to keep the timer running; return false to stop the timer
                    return true;
                });
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }

        private void LocationListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            
            var selectedLocation = e.SelectedItem as LocationView;
            DisplayAlert("Selected Location", $"Latitude: {selectedLocation?.Latitude}\nLongitude: {selectedLocation?.Longitude}\nTimestamp: {selectedLocation?.Timestamp}", "OK");
           
            ((ListView)sender).SelectedItem = null;
        }

        private void RefreshData()
        {
            locationListView.ItemsSource = null;
            OnAppearing();
        }

        private async void NavigateToSettings()
        {

            await Navigation.PushAsync(new Location());
        }


        private async void OnTrackLocationClicked(object sender, EventArgs e)
        {

            var request = new GeolocationRequest(GeolocationAccuracy.High);
            var location = await Geolocation.GetLocationAsync(request);
            //var location = await Geolocation.GetLastKnownLocationAsync();
            if (location != null)
            {
                var apiLocation = new LocationView
                {
                    Latitude = location.Latitude.ToString(),
                    Longitude = location.Longitude.ToString(),
                    //Timestamp = DateTime.UtcNow, 
                    UserId = 1

                };


                await _locationService.SendLocationAsync(apiLocation);

                // Update UI or perform additional actions...
            }
            else
            {
                // Handle location not available
            }
        }

        private async void CheckAndRequestLocationPermission()
        {
            try
            {
                var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

                if (status == PermissionStatus.Granted)
                {
                    addCurrentLocation();
                }
                else if (status == PermissionStatus.Denied)
                {
                    status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();

                    if (status == PermissionStatus.Granted)
                    {
                        addCurrentLocation();
                    }
                    else
                    {
                        DisplayAlert("Permission Denied", "Location permission is required to use this feature.", "OK");
                    }
                }
                else if (status == PermissionStatus.Disabled)
                {
                    // Location permission is disabled, prompt user to enable it
                    DisplayLocationSettingsRequest();
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine($"Error: {ex.Message}");
            }
        }


        private async void saveButton_Clicked(object sender, EventArgs e)
        {

            CheckAndRequestLocationPermission();

        }

        private async void addCurrentLocation()
        {
            var request = new GeolocationRequest(GeolocationAccuracy.High);
            var location = await Geolocation.GetLocationAsync(request);
            //var location = await Geolocation.GetLastKnownLocationAsync();
            if (location != null)
            {
                DateTime currentUtcDateTime = DateTime.UtcNow;
                string formattedDateTime = currentUtcDateTime.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
                var apiLocation = new LocationView
                {
                    Latitude = location.Latitude.ToString(),
                    Longitude = location.Longitude.ToString(),
                    Timestamp = formattedDateTime,
                    UserId = 1

                };


                //await _locationService.SendLocationAsync(apiLocation);

                HttpClient _client = new HttpClient();

                var uri = new Uri(Constants.BaseAddress + "/Location");
                var responseModel = await RestUtil<LocationView, LocationView>.Post(uri, apiLocation, false);

                if (responseModel.IsSuccess)
                {
                    var res = responseModel.IsSuccess;
                }
            }

        }

        private async void DisplayLocationSettingsRequest()
        {
            bool result = await DisplayAlert("Location Services Not Enabled", "Please enable location services to use this feature.", "Go to Settings", "Cancel");

            if (result)
            {
                // Open the device settings to enable location services
                await Launcher.OpenAsync(new Uri("app-settings:"));
            }
            else
            {
                // Handle cancel button click
                // ...
            }
        }


    }
}