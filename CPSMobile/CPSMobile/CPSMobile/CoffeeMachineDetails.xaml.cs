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
	public partial class CoffeeMachineDetails : ContentPage
	{
		public CoffeeMachineDetails ()
		{

			InitializeComponent ();

            CoffeeDeviceState coffeeDevice = Logic.GetCoffeeDeviceState();
            Coffee.Value = coffeeDevice.currentCoffeeAmount;
            Water.Value = coffeeDevice.currentWaterAmount;
            Milk.Value = coffeeDevice.currentMilkAmount;
		}

        private void MakeCoffee(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new MakeCoffee()));
        }
    }
}