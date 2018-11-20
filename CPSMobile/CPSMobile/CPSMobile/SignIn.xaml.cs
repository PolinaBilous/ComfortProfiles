using CPSMobile.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CPSMobile
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SignIn : ContentPage
	{
        private readonly string clientURL = "http://abd38c4e.ngrok.io";

        public SignIn ()
		{
			InitializeComponent ();
		}

        void SignInAction(object sender, EventArgs args)
        {
            var client = new RestClient(clientURL);

            var request = new RestRequest("api/User/Login?email=" + Email.Text + "&password=" + Password.Text, Method.POST);

            IRestResponse<AppUserResponse> response = client.Execute<AppUserResponse>(request);

            if (response.Data.Message == "ok")
            {
                DisplayAlert("Notification", "You have been successfuly signed in!", "OK");
            }
            else
            {
                DisplayAlert("Notification", "Email or password is incorrect. Please try again!", "OK");
            }
        }

        void OpenSignIn(object sender, EventArgs args)
        {
        }

        void OpenSignUp(object sender, EventArgs args)
        {

        }
    }
}