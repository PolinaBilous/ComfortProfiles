using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CPSMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RoomsMaster : ContentPage
    {
        public ListView ListView;

        public RoomsMaster()
        {
            InitializeComponent();

            BindingContext = new RoomsMasterViewModel();
            ListView = MenuItemsListView;
        }

        class RoomsMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<object> MenuItems { get; set; }
            
            public RoomsMasterViewModel()
            {
                MenuItems = new ObservableCollection<object>(new object[]
                {
                    new RoomsMenuItem { Id = 0, Title = "Rooms climat and illumination", TargetType=typeof(RoomsDetail) },
                    new RoomsMenuItem { Id = 1, Title = "Coffee Machine", TargetType=typeof(CoffeeMachineDetails) },
                    new RoomsMenuItem { Id = 2, Title = "Teapot", TargetType = typeof(TeapotDetails) },
                    new RoomsMenuItem { Id = 3, Title = "Comfort profile", TargetType = typeof(StaticInfoDetails) }
                });
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }

        async void SignOut(object sender, EventArgs args)
        {
            Logic.SignOut();
            await Navigation.PushModalAsync(new NavigationPage(new SignIn()));
        }
    }
}