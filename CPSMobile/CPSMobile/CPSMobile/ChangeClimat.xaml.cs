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
    class PickerValue
    {
        public int NumberValue { get; set; }
        public string StringValue { get; set; }
    }

	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChangeClimat : ContentPage
	{
        private string roomId;

		public ChangeClimat ()
		{
			InitializeComponent ();
		}

        public ChangeClimat(string roomId)
        {
            this.roomId = roomId;
            List<Room> rooms = Logic.GetUserRooms();
            Room room = rooms.FirstOrDefault(r => r.Id == roomId);

            List<PickerValue> temperatureValues = new List<PickerValue>();
            for (int i = 15; i <= 35; i++) {
                temperatureValues.Add(new PickerValue() { NumberValue = i, StringValue = i.ToString() + "°C" });
            }

            List<PickerValue> airHumidityValues = new List<PickerValue>();
            for (int i = 10; i <= 65; i += 1)
            {
                airHumidityValues.Add(new PickerValue() { NumberValue = i, StringValue = i.ToString() + "%"});
            }

            List<HowOften> howOftens = Logic.GetHowOftens();

            DateTime minimumDate = DateTime.Now;
            
            InitializeComponent();

            Temperature.ItemsSource = temperatureValues;
            Temperature.SelectedItem = temperatureValues.FirstOrDefault(t => t.NumberValue == room.currentTemperature);

            AirHumidity.ItemsSource = airHumidityValues;
            AirHumidity.SelectedItem = airHumidityValues.FirstOrDefault(a => a.NumberValue == room.CurrentAirHumidity);

            IsRepeatable.ItemsSource = howOftens;
            IsRepeatable.SelectedItem = howOftens.FirstOrDefault(ho => ho.Id == 1);
        }

        public void SubmitChangeClimat(object sender, EventArgs args)
        {
            int temperature = (Temperature.SelectedItem as PickerValue).NumberValue;
            int airHumidity = (AirHumidity.SelectedItem as PickerValue).NumberValue;
            int howOftenId = (IsRepeatable.SelectedItem as HowOften).Id;
            DateTime date = Date.Date.Add(Time.Time).AddHours(-3);
            
            var resultDateString = String.Format("{0:s}", date);

            var requestResult = Logic.ChangeClimat(roomId, temperature, airHumidity, howOftenId, resultDateString);
            var message = requestResult[0].Value as string;

            if (message == "ok")
                Navigation.PushModalAsync(new NavigationPage(new Rooms()));
        }
    }
}