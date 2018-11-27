using CPSMobile.Models;
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
    public partial class TeapotDetails : ContentPage
    {
        public TeapotDetails()
        {           
            InitializeComponent();

            TeapotState teapotState = Logic.GetTeapotState();
            Water.Value = teapotState.currentWaterAmount;
            Temperature.Value = teapotState.currentTemperature;
        }

        protected override void OnAppearing()
        {
            TeapotState teapotState = Logic.GetTeapotState();
            Water.Value = teapotState.currentWaterAmount;
            Temperature.Value = teapotState.currentTemperature;
        }

        private void BoilWater(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new BoilWater()));
        }
    }
}