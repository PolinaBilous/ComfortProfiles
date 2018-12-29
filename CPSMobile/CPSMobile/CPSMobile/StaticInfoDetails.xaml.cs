
using CPSMobile.Models;
using Microcharts;
using SkiaSharp;
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
	public partial class StaticInfoDetails : ContentPage
	{
        public StaticInfoDetails()
        {
            List<CoffeeType> watertypes = Logic.GetWaterTypes();
            List<CoffeeType> mattressTypes = Logic.GetMattressTypes();
            List<CoffeeType> tableTypes = Logic.GetTableTypes();
            List<CoffeeType> chairTypes = Logic.GetChairTypes();
            List<CoffeeType> coffeeTypes = Logic.GetCoffeeTypes();
            List<HowOften> howOftens = Logic.GetHowOftens();

            ComfortProfile comfortProfile = Logic.GetComfortProfile();

            InitializeComponent();

            Body.Children.Add(new Label()
            {
                Text = "It's your comfort profile. You can share it by link using button in the bottom of the page.",
                TextColor = Color.Black,
                FontFamily = "Raleway-Medium.ttf#Raleway",
                FontSize = 19,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Margin = new Thickness(20, 18, 20, 0)
            });

            Body.Children.Add(new Label()
            {
                Text = "Personal: ",
                TextColor = Color.Black,
                FontFamily = "Raleway-Bold.ttf#Raleway",
                FontSize = 18,
                Margin = new Thickness(20, 5, 20, 0)
            });

            var shoeSizeImage = new Image()
            {
                Source = "shoe.png",
                Margin = new Thickness(20, 14, 5, 0)
            };

            var shoeSizeLabel = new Label()
            {
                Text = "Shoe size: " + comfortProfile.shoeSize,
                TextColor = Color.Black,
                FontFamily = "Raleway-Medium.ttf#Raleway",
                FontSize = 17,
                Margin = new Thickness(5, 23, 5, 0)
            };

            Body.Children.Add(new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Children = { shoeSizeImage, shoeSizeLabel }
            });

            var clothesSizeImage = new Image()
            {
                Source = "clothes.png",
                Margin = new Thickness(20, 14, 5, 0)
            };

            var clothesSizeLabel = new Label()
            {
                Text = "Clothing size: " + comfortProfile.clothingSize,
                TextColor = Color.Black,
                FontFamily = "Raleway-Medium.ttf#Raleway",
                FontSize = 17,
                Margin = new Thickness(5, 23, 5, 0)
            };

            Body.Children.Add(new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Children = { clothesSizeImage, clothesSizeLabel }
            });

            var allergensImage = new Image()
            {
                Source = "allergens.png",
                Margin = new Thickness(20, 14, 5, 0)
            };

            var allergensLabel = new Label()
            {
                Text = "Allergens: " + comfortProfile.allergens,
                TextColor = Color.Black,
                FontFamily = "Raleway-Medium.ttf#Raleway",
                FontSize = 17,
                Margin = new Thickness(5, 23, 5, 0)
            };

            Body.Children.Add(new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Children = { allergensImage, allergensLabel }
            });

            var musicalPreferencesImage = new Image()
            {
                Source = "music.png",
                Margin = new Thickness(20, 14, 5, 0)
            };

            var musicalPreferencesLabel = new Label()
            {
                Text = comfortProfile.musicalPreferences,
                TextColor = Color.Black,
                FontFamily = "Raleway-Medium.ttf#Raleway",
                FontSize = 17,
                Margin = new Thickness(5, 23, 5, 0)
            };

            Body.Children.Add(new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Children = { musicalPreferencesImage, musicalPreferencesLabel }
            });

            var fruitPreferencesImage = new Image()
            {
                Source = "fruit.png",
                Margin = new Thickness(20, 14, 5, 0)
            };

            var fruitPreferencesLabel = new Label()
            {
                Text = "Fruits preferences: " + comfortProfile.fruitPreferences,
                TextColor = Color.Black,
                FontFamily = "Raleway-Medium.ttf#Raleway",
                FontSize = 17,
                Margin = new Thickness(5, 23, 5, 0)
            };

            Body.Children.Add(new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Children = { fruitPreferencesImage, fruitPreferencesLabel }
            });

            Body.Children.Add(new Label()
            {
                Text = "House: ",
                TextColor = Color.Black,
                FontFamily = "Raleway-Bold.ttf#Raleway",
                FontSize = 18,
                Margin = new Thickness(20, 15, 20, 0)
            });

            var chairTypeImage = new Image()
            {
                Source = "chair.png",
                Margin = new Thickness(20, 14, 5, 0)
            };

            var chairTypeLable = new Label()
            {
                Text = "Preferable chair type: " + chairTypes.FirstOrDefault(chairType => chairType.Id == comfortProfile.chairTypeId.ToString()).Name,
                TextColor = Color.Black,
                FontFamily = "Raleway-Medium.ttf#Raleway",
                FontSize = 17,
                Margin = new Thickness(5, 21, 5, 0)
            };

            Body.Children.Add(new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Children = { chairTypeImage, chairTypeLable }
            });

            var tableTypeImage = new Image()
            {
                Source = "table.png",
                Margin = new Thickness(20, 14, 5, 0)
            };

            var tableTypeLabel = new Label()
            {
                Text = "Preferable table type: " + tableTypes.FirstOrDefault(tableType => tableType.Id == comfortProfile.tableTypeId.ToString()).Name,
                TextColor = Color.Black,
                FontFamily = "Raleway-Medium.ttf#Raleway",
                FontSize = 17,
                Margin = new Thickness(5, 21, 5, 0)
            };

            Body.Children.Add(new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Children = { tableTypeImage, tableTypeLabel }
            });

            var mattressTypeImage = new Image()
            {
                Source = "mattress.png",
                Margin = new Thickness(20, 14, 5, 0)
            };

            var mattressTypeLabel = new Label()
            {
                Text = "Preferable mattress type: " + mattressTypes.FirstOrDefault(mattressType => mattressType.Id == comfortProfile.mattressTypeId.ToString()).Name,
                TextColor = Color.Black,
                FontFamily = "Raleway-Medium.ttf#Raleway",
                FontSize = 17,
                Margin = new Thickness(5, 21, 5, 0)
            };

            Body.Children.Add(new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Children = { mattressTypeImage, mattressTypeLabel }
            });

            Body.Children.Add(new Label()
            {
                Text = "Rooms: ",
                TextColor = Color.Black,
                FontFamily = "Raleway-Medium.ttf#Raleway",
                FontSize = 18,
                Margin = new Thickness(20, 15, 20, 0)
            });

            foreach (var room in comfortProfile.preferableRoomsIndicators)
            {
                Random rand = new Random();

                var frame = new Frame()
                {
                    BorderColor = Color.White,
                    CornerRadius = 2,
                    HasShadow = true,
                    HeightRequest = 160
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
                    Text = room.name,
                    FontAttributes = FontAttributes.Bold,
                    FontSize = 29,
                    FontFamily = "Raleway-Bold.ttf#Raleway",
                    TextColor = Color.White,
                    Margin = new Thickness(20, 10, 0, 2)
                });

                if (room.preferableTemperature == null)
                {
                    room.preferableTemperature = rand.Next(20, 40);
                }

                roomCard.Children.Add(new Label()
                {
                    Text = "Preferable Temperature: " + room.preferableTemperature + "°C",
                    FontSize = 18,
                    FontFamily = "Raleway-Medium.ttf#Raleway",
                    TextColor = Color.White,
                    Margin = new Thickness(20, 2)
                });

                if (room.preferableAirHumidity == null)
                {
                    room.preferableAirHumidity = rand.Next(20, 60);
                }

                roomCard.Children.Add(new Label()
                {
                    Text = "Preferable Air Humidity: " + room.preferableAirHumidity + "%",
                    FontSize = 18,
                    FontFamily = "Raleway-Medium.ttf#Raleway",
                    TextColor = Color.White,
                    Margin = new Thickness(20, 2)
                });

                if (room.preferableLightIntencity == null)
                {
                    room.preferableLightIntencity = rand.Next(30, 100);
                }

                roomCard.Children.Add(new Label()
                {
                    Text = "Preferable Light Intensity: " + room.preferableLightIntencity + "%",
                    FontSize = 18,
                    FontFamily = "Raleway-Medium.ttf#Raleway",
                    TextColor = Color.White,
                    Margin = new Thickness(20, 2)
                });

                grid.Children.Add(image);
                grid.Children.Add(roomCard);
                frame.Content = grid;
                Body.Children.Add(frame);
            }

            Body.Children.Add(new Label()
            {
                Text = "Other: ",
                TextColor = Color.Black,
                FontFamily = "Raleway-Bold.ttf#Raleway",
                FontSize = 18,
                Margin = new Thickness(20, 15, 20, 0)
            });

            var teapotImage = new Image()
            {
                Source = "temperature.png",
                Margin = new Thickness(20, 14, 5, 0)
            };

            var teapotLabel = new Label()
            {
                Text = "Preferable water in teapot temperature: " + comfortProfile.comfortTeapotTemperature + "°C",
                TextColor = Color.Black,
                FontFamily = "Raleway-Medium.ttf#Raleway",
                FontSize = 17,
                Margin = new Thickness(5, 21, 5, 0)
            };

            Body.Children.Add(new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Children = { teapotImage, teapotLabel }
            });

            var teaImage = new Image()
            {
                Source = "tea.png",
                Margin = new Thickness(20, 14, 5, 0)
            };

            var teaLabel = new Label()
            {
                Text = "Favourite kinds of tea" + comfortProfile.kindOfTea,
                TextColor = Color.Black,
                FontFamily = "Raleway-Medium.ttf#Raleway",
                FontSize = 17,
                Margin = new Thickness(5, 21, 5, 0)
            };

            Body.Children.Add(new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Children = { teaImage, teaLabel }
            });

            var teaTimesImage = new Image()
            {
                Source = "time.png",
                Margin = new Thickness(20, 14, 5, 0)
            };

            var teaTimesLabel = new Label()
            {
                Text = "Times when water should be boiled up to specific temperature:",
                TextColor = Color.Black,
                FontFamily = "Raleway-Medium.ttf#Raleway",
                FontSize = 17,
                Margin = new Thickness(5, 21, 5, 0)
            };

            Body.Children.Add(new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Children = { teaTimesImage, teaTimesLabel }
            });

            if (comfortProfile.preferableTeaTimes != null)
            {
                foreach (var ptt in comfortProfile.preferableTeaTimes)
                {
                    Body.Children.Add(new Label()
                    {
                        Text = "Boil water to " + ptt.temperature + "°C" + howOftens.FirstOrDefault(ho => ho.Id == ptt.howOftenId).Explanation + " at " + ptt.date.ToShortTimeString(),
                        TextColor = Color.Black,
                        FontFamily = "Raleway-Medium.ttf#Raleway",
                        FontSize = 17,
                        Margin = new Thickness(67, 8, 5, 0)
                    });
                }
            }
            else {
                Body.Children.Add(new Label()
                {
                    Text = "Unfoturnately, we don't have needed amount of information to fill this section.",
                    TextColor = Color.Black,
                    FontFamily = "Raleway-Medium.ttf#Raleway",
                    FontSize = 17,
                    Margin = new Thickness(67, 8, 5, 0)
                });
            }

            Body.Children.Add(new Label()
            {
                Text = "Favourite coffee types: ",
                TextColor = Color.Black,
                FontFamily = "Raleway-Medium.ttf#Raleway",
                FontSize = 17,
                Margin = new Thickness(20, 14, 5, 0)
            });

            List<Microcharts.Entry> entries = new List<Microcharts.Entry>();
            Random r = new Random();

            foreach (var fct in comfortProfile.favoriteCoffeeTypes)
            {
                var value = r.Next(20, 60);

                entries.Add(new Microcharts.Entry(value)
                {
                    Color = SKColor.FromHsl(r.Next(0, 265), r.Next(0, 265), r.Next(0, 265)),
                    Label = coffeeTypes.First(ct => ct.Id == fct.id).Name,
                    ValueLabel = value.ToString() + "%"
                });
            }

            FavouriteCoffeeChart.Chart = new DonutChart() { Entries = entries };

            var coffeeTimesImage = new Image()
            {
                Source = "time.png",
                Margin = new Thickness(20, 14, 5, 0)
            };

            var coffeeTimesLabel = new Label()
            {
                Text = "When coffee should be done: ",
                TextColor = Color.Black,
                FontFamily = "Raleway-Medium.ttf#Raleway",
                FontSize = 17,
                Margin = new Thickness(5, 21, 5, 0)
            };

            ContinueBody.Children.Add(new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Children = { coffeeTimesImage, coffeeTimesLabel }
            });

            if (comfortProfile.preferableCoffeeTimes != null)
            {
                foreach (var ptt in comfortProfile.preferableCoffeeTimes)
                {
                    ContinueBody.Children.Add(new Label()
                    {
                        Text = "Make " + coffeeTypes.FirstOrDefault(ct => ct.Id == ptt.coffeeTypeId).Name + " " + howOftens.FirstOrDefault(ho => ho.Id == ptt.howOftenId).Explanation + " at " + ptt.date.ToShortTimeString(),
                        TextColor = Color.Black,
                        FontFamily = "Raleway-Medium.ttf#Raleway",
                        FontSize = 17,
                        Margin = new Thickness(67, 8, 5, 0)
                    });
                }
            }
            else
            {
                ContinueBody.Children.Add(new Label()
                {
                    Text = "Unfoturnately, we don't have needed amount of information to fill these sectoin.",
                    TextColor = Color.Black,
                    FontFamily = "Raleway-Medium.ttf#Raleway",
                    FontSize = 17,
                    Margin = new Thickness(67, 8, 5, 0)
                });
            }
        }

        private void Share(object sender, EventArgs e)
        {

        }
    }
}