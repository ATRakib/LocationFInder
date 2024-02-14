using LocationFInderApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LocationFInderApp.Data
{
    public class SessionUtil
    {
        public static async Task SetnSession(string key, object obj)
        {
            Application.Current.Properties[key] = obj;

            await Application.Current.SavePropertiesAsync();
        }

        public static object GetFromSession(string key)
        {
            if (Application.Current.Properties.ContainsKey(key))
            {
                return Application.Current.Properties[key];
            }
            else
            {
                return null;
            }
        }

        public static async Task SetUserInSession(UserLoginResponseModel user)
        {
            Application.Current.Properties["user"] = user;
            Application.Current.Properties["userId"] = user.Id;
            Application.Current.Properties["IsUserLoggedIn"] = true;
            Application.Current.Properties["UserRoleId"] = user.DefaultRoleId;
            Application.Current.Properties["Token"] = user.JwtToken;

            await Application.Current.SavePropertiesAsync();
        }

        public static bool IsLoggedIn()
        {
            if (Application.Current.Properties.ContainsKey("IsUserLoggedIn") && (bool)Application.Current.Properties["IsUserLoggedIn"] == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string GetToken()
        {
            if (Application.Current.Properties.ContainsKey("Token"))
            {
                return (string)Application.Current.Properties["Token"];
            }
            else
            {
                return "";
            }
        }

        public static string GetUserId()
        {
            if (Application.Current.Properties.ContainsKey("userId"))
            {
                return (string)Application.Current.Properties["userId"];
            }
            else
            {
                return "";
            }
        }
    }
}
