using CPSMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Type = CPSMobile.Models.Type;

namespace CPSMobile
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MakeCoffee : ContentPage
	{
		public MakeCoffee ()
		{
            List<Type> coffeeTypes = Logic.GetCoffeeTypes();
            List<HowOften> howOftens = Logic.GetHowOftens();

            DateTime minimumDate = DateTime.Now;

            InitializeComponent ();

            CoffeTypeSelector.ItemsSource = coffeeTypes;


            IsRepeatable.ItemsSource = howOftens;
            IsRepeatable.SelectedItem = howOftens.FirstOrDefault(ho => ho.Id == 1);
        }

        async private void Submit(object sender, EventArgs e)
        {
            string coffeeType = (CoffeTypeSelector.SelectedItem as Type).Id;
            int howOftenId = (IsRepeatable.SelectedItem as HowOften).Id;
            DateTime date = Date.Date.Add(Time.Time).AddHours(-3);

            var resultDateString = String.Format("{0:s}", date);

            var message = Logic.MakeCupOfCoffee(coffeeType, resultDateString, howOftenId);

            if (message == "ok")
            {
                await Navigation.PopModalAsync();
            }
            else
            {
                await ShowMessage("Opps! You don't have enough milk, water or coffee.", "Notification:", "Ok", async() =>
                {
                    await Navigation.PopModalAsync();
                });
            }
        }

        public async Task ShowMessage(string message,
           string title,
           string buttonText,
           Action afterHideCallback)
        {
            await DisplayAlert(
                title,
                message,
                buttonText);

            afterHideCallback?.Invoke();
        }
    }
}