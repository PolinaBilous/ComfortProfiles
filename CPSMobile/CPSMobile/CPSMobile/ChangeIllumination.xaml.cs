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
    public partial class ChangeIllumination : ContentPage
    {
        private string roomId;

        public ChangeIllumination()
        {
            InitializeComponent();
        }

        public ChangeIllumination(string roomId)
        {
            this.roomId = roomId;
            List<Room> rooms = Logic.GetUserRooms();
            Room room = rooms.FirstOrDefault(r => r.Id == roomId);

            List<PickerValue> lightIntensityValues = new List<PickerValue>();
            for (int i = 0; i <= 100; i+=5)
            {
                lightIntensityValues.Add(new PickerValue() { NumberValue = i, StringValue = i.ToString() + "%" });
            }

            List<PickerValue> isLightValues = new List<PickerValue>();
            isLightValues.Add(new PickerValue() { NumberValue = 0, StringValue = "Off" });
            isLightValues.Add(new PickerValue() { NumberValue = 1, StringValue = "On" });

            List<HowOften> howOftens = Logic.GetHowOftens();

            DateTime minimumDate = DateTime.Now;

            InitializeComponent();

            IsLight.ItemsSource = isLightValues;
            IsLight.SelectedItem = isLightValues.FirstOrDefault(l => l.NumberValue == Convert.ToInt32(room.currentIsLight));

            LightIntensity.ItemsSource = lightIntensityValues;
            LightIntensity.SelectedItem = lightIntensityValues.FirstOrDefault(l => l.NumberValue == room.currentLightIntensity);

            IsRepeatable.ItemsSource = howOftens;
            IsRepeatable.SelectedItem = howOftens.FirstOrDefault(ho => ho.Id == 1);
        }

        public void SubmitChangeIllumination(object sender, EventArgs args)
        {
            int lightIntensity = (LightIntensity.SelectedItem as PickerValue).NumberValue;
            bool isLight = (IsLight.SelectedItem as PickerValue).NumberValue == 1 ? true : false;

            int howOftenId = (IsRepeatable.SelectedItem as HowOften).Id;
            DateTime date = Date.Date.Add(Time.Time).AddHours(-3);

            var resultDateString = String.Format("{0:s}", date);

            var requestResult = Logic.ChangeIllumination(roomId, isLight, lightIntensity, howOftenId, resultDateString);
            var message = requestResult[0].Value as string;

            if (message == "ok")
                Navigation.PushModalAsync(new NavigationPage(new Rooms()));
        }

    }
}