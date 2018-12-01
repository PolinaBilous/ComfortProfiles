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
                    BorderColor = Color.White,
                    CornerRadius = 10,
                    HasShadow = true,
                    Margin = new Thickness(0, 4, 0, 4),
                    HeightRequest = 250
                };

                var image = new Image()
                {
                    Source = "test.jpg",
                    Aspect = Aspect.Fill
                };
                var grid = new Grid();
                var roomCard = new StackLayout();

                roomCard.Children.Add(new Label()
                {
                    Text = room.Name,
                    FontAttributes = FontAttributes.Bold,
                    FontSize = 29,
                    FontFamily = "Raleway-Bold.ttf#Raleway",
                    TextColor = Color.White,
                    Margin = new Thickness(20, 10, 0, 2)
                });
                roomCard.Children.Add(new Label()
                {
                    Text = "Current Temperature: " + room.currentTemperature + "°C",
                    FontSize = 18,
                    FontFamily = "Raleway-Medium.ttf#Raleway",
                    TextColor = Color.White,
                    Margin = new Thickness(20, 2)
                });

                roomCard.Children.Add(new Label()
                {
                    Text = "Current Air Humidity: " + room.CurrentAirHumidity + "%",
                    FontSize = 18,
                    FontFamily = "Raleway-Medium.ttf#Raleway",
                    TextColor = Color.White,
                    Margin = new Thickness(20, 2)
                });

                var light = new Label()
                {
                    FontSize = 18,
                    FontFamily = "Raleway-Medium.ttf#Raleway",
                    TextColor = Color.White,
                    Margin = new Thickness(20, 2)
                };

                if (room.currentIsLight)
                {
                    light.Text = "Light is on";
                }
                else
                {
                    light.Text = "Light is off";
                }

                roomCard.Children.Add(light);

                roomCard.Children.Add(new Label()
                {
                    Text = "Current Light Intensity: " + room.currentLightIntensity + "%",
                    FontSize = 18,
                    FontFamily = "Raleway-Medium.ttf#Raleway",
                    TextColor = Color.White,
                    Margin = new Thickness(20, 2)
                });

                var changeClimatButton = new Button()
                {
                    Text = "Change climat",
                    AutomationId = room.Id,
                    WidthRequest = 135,
                    Margin = new Thickness(20, 4, 0, 0),
                    TextColor = Color.Black,
                    FontFamily = "Raleway-Bold.ttf#Raleway"

                };
                changeClimatButton.Clicked += ChangeClimat;

                var changeLightButton = new Button()
                {
                    
                    Text = "Change illumination",
                    AutomationId = room.Id, 
                    WidthRequest = 135,
                    Margin = new Thickness(7, 4, 0, 0),
                    TextColor = Color.Black,
                    FontFamily = "Raleway-Bold.ttf#Raleway"
                };
                changeLightButton.Clicked += ChangeLight;

                roomCard.Children.Add(new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.StartAndExpand,
                    Children = { changeClimatButton, changeLightButton }
                });
                

                grid.Children.Add(image);
                grid.Children.Add(roomCard);
                frame.Content = grid;
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