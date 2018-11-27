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
	public partial class BoilWater : ContentPage
	{
		public BoilWater ()
		{
            List<HowOften> howOftens = Logic.GetHowOftens();

            DateTime minimumDate = DateTime.Now;

            InitializeComponent();


            IsRepeatable.ItemsSource = howOftens;
            IsRepeatable.SelectedItem = howOftens.FirstOrDefault(ho => ho.Id == 1);

            Temperature.ValueChanged += (sender, args) =>
            {
                SelectedTemperature.Text = String.Format("Selected temperature: " + Temperature.Value + "°C");
            };
        }

        async private void Submit(object sender, EventArgs e)
        {
            int temperature = Convert.ToInt32(Temperature.Value);
            int howOftenId = (IsRepeatable.SelectedItem as HowOften).Id;
            DateTime date = Date.Date.Add(Time.Time).AddHours(-3);

            var resultDateString = String.Format("{0:s}", date);

            var message = Logic.BoilWater(temperature, resultDateString, howOftenId);

            if (message == "ok")
            {
                await Navigation.PopModalAsync();
            }
            else
            {
                await ShowMessage("Opps! You don't have enough water.", "Notification:", "Ok", async () =>
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