using LocationFInderApp.Data;
using LocationFInderApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LocationFInderApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddUserPage : ContentPage
    {
        
        public AddUserPage()
        {
            InitializeComponent();
           
        }

        private async void OnAddClicked(object sender, EventArgs e)
        {
            try
            {
                var name = nameEntry.Text;
                var email = emailEntry.Text;

                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email))
                {
                    await DisplayAlert("Error", "Please enter both name and email.", "OK");
                    return;
                }
                var newUser = new User
                {
                    Id = 0,
                    Name = nameEntry.Text,
                    Email = emailEntry.Text
                };


                HttpClient _client = new HttpClient();
                var uri = new Uri(Constants.BaseAddress + "/User");
                var responseModel = await RestUtil<User, User>.Post(uri, newUser, false);

                if (responseModel.IsSuccess)
                {
                    // Reset input values
                    nameEntry.Text = "";
                    emailEntry.Text = "";

                    await DisplayAlert("Success", "User added successfully!", "OK");
                    return;
                }
                else
                {
                    // Reset input values
                    nameEntry.Text = "";
                    emailEntry.Text = "";
                    await DisplayAlert("Error", "User Not Created!", "OK");
                    return;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            

            
        }

      
    }
}