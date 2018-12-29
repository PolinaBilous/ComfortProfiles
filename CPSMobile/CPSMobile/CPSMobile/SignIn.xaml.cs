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

        public SignIn ()
		{
			InitializeComponent ();
		}

        void SignInAction(object sender, EventArgs args)
        {
            AppUserResponse userResponse = Logic.SignIn(Email.Text, Password.Text);

            if (userResponse.Message == "ok")
            {
                //DisplayAlert("Notification", "You have been successfuly signed in!", "OK");
                Navigation.PushModalAsync(new NavigationPage(new Rooms()));
            }
            else
            {
                DisplayAlert("Notification", "Email or password is incorrect. Please try again!", "OK");
            }
        }

        async void OpenSignUp(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new NavigationPage(new SignUp()));
        }
    }
}