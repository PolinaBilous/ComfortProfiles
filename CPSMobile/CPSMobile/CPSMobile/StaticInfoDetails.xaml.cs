
using CPSMobile.Models;
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
		public StaticInfoDetails ()
		{
            List<Type> watertypes = Logic.GetWaterTypes();
            List<Type> mattressTypes = Logic.GetMattressTypes();
            List<Type> tableTypes = Logic.GetTableTypes();
            List<Type> chairTypes = Logic.GetChairTypes();

            StaticInfo staticInfo = Logic.GetStaticInfo();

            InitializeComponent ();

            Body.Children.Add(new Label()
            {
                Text = "Clothing size: " + staticInfo.ClothingSize
            });

            Body.Children.Add(new Label()
            {
                Text = "Shoe size: " + staticInfo.ShoeSize
            });

            Body.Children.Add(new Label()
            {
                Text = "Allergens: " + staticInfo.Allergens
            });

            Body.Children.Add(new Label()
            {
                Text = "Favourite kinds of tea: " + staticInfo.KindOfTea
            });

            Body.Children.Add(new Label()
            {
                Text = "Favourite kinds of coffee: " + staticInfo.KindOfCoffee
            });

            Body.Children.Add(new Label()
            {
                Text = staticInfo.MusicalPreferences
            });

            Body.Children.Add(new Label()
            {
                Text = "Favourite fruits: " + staticInfo.FruitPreferences
            });

            Body.Children.Add(new Label()
            {
                Text = "Preferable chair type: " + chairTypes.FirstOrDefault(c => c.Id == staticInfo.ChairTypeId).Name
            });


            Body.Children.Add(new Label()
            {
                Text = "Preferable mattress type: " + mattressTypes.FirstOrDefault(c => c.Id == staticInfo.MattressTypeId).Name
            });

            Body.Children.Add(new Label()
            {
                Text = "Preferable table type: " + tableTypes.FirstOrDefault(c => c.Id == staticInfo.TableTypeId).Name
            });

            Body.Children.Add(new Label()
            {
                Text = "Preferable water type: " + chairTypes.FirstOrDefault(c => c.Id == staticInfo.WaterTypeId).Name
            });
        }
	}
}