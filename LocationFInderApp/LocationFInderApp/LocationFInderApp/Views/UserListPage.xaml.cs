using LocationFInderApp.Data;
using LocationFInderApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LocationFInderApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserListPage : ContentPage
    {
        public ObservableCollection<User> Users { get; set; }

        public UserListPage()
        {
            InitializeComponent();
           
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                var uri = new Uri(Constants.BaseAddress + "/User");
                var modelResponse = await RestUtil<List<User>, User>.Get(uri);

                if (modelResponse != null && modelResponse.Data != null)
                {
                    userListView.ItemsSource = modelResponse.Data;
                }
                else
                {
                    DisplayAlert("Error", "Failed to fetch location data.", "OK");
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }

        private void UserListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var selectedLocation = e.SelectedItem as User;
            DisplayAlert("Selected User", $"Name: {selectedLocation?.Name}\nEmail: {selectedLocation?.Email}", "OK");

            ((ListView)sender).SelectedItem = null;
        }

        private async void OnAddUserClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddUserPage());
        }
    }

}