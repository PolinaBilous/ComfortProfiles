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
    public partial class RoomsDetail : ContentPage
    {
        public RoomsDetail()
        {
            InitializeComponent();

            List<Room> rooms = Logic.GetUserRooms();
            List<StackLayout> roomsCards = new List<StackLayout>();
            foreach(var room in rooms)
            {
                var frame = new Frame()
                {
                    BorderColor = Color.Gray,
                    CornerRadius = 10,
                    HasShadow = true,
                    Margin = new Thickness(10, 5)
                };
                var roomCard = new StackLayout();

                roomCard.Children.Add(new Label()
                {
                    Text = room.Name,
                    FontAttributes = FontAttributes.Bold,
                    FontSize = 20
                });
                roomCard.Children.Add(new Label()
                {
                    Text = "Current Temperature: " + room.currentTemperature,
                    FontSize = 17
                });

                roomCard.Children.Add(new Label()
                {
                    Text = "Current Air Humidity: " + room.CurrentAirHumidity,
                    FontSize = 17
                });

                roomCard.Children.Add(new Label()
                {
                    Text = "Is Light: " + room.currentIsLight.ToString(),
                    FontSize = 17
                });

                roomCard.Children.Add(new Label()
                {
                    Text = "Current Light Intensity: " + room.currentLightIntensity,
                    FontSize = 17
                });

                var changeClimatButton = new Button()
                {
                    Text = "Change climat",
                    AutomationId = room.Id

                };
                changeClimatButton.Clicked += ChangeClimat;
                roomCard.Children.Add(changeClimatButton);

                var changeLightButton = new Button()
                {
                    
                    Text = "Change light",
                    AutomationId = room.Id
                };
                changeLightButton.Clicked += ChangeLight;
                roomCard.Children.Add(changeLightButton);

                frame.Content = roomCard;
                Body.Children.Add(frame);
            }
        }

        async void ChangeClimat(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new NavigationPage(new ChangeClimat((sender as Button).AutomationId)));
        }

        async void ChangeLight(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new NavigationPage(new ChangeIllumination((sender as Button).AutomationId)));
        }
    }
}