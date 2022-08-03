
using Order_Eats.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Order_Eats.FoodPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMeals : ContentPage
    {

        string category = "Mains";
        public MainMeals()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            showMainMeals.ItemsSource = await App.DatabaseCon.GetRecipeAsync(category);
        }

        async void addMains_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RecipePages.RecipeMainMeals());
        }

        async void Edit_Invoked(object sender, EventArgs e)
        {
            var mainItems = sender as SwipeItem;
            var mainMenu = mainItems.CommandParameter as MenuItems;
            await Navigation.PushAsync(new RecipePages.RecipeMainMeals(mainMenu));
        }

        async void Delete_Invoked(object sender, EventArgs e)
        {
            var mainItems = sender as SwipeItem;
            var mainMenu = mainItems.CommandParameter as MenuItems;
            var MainResults = await DisplayAlert("Delete", "Are you sure you want to delete this item", "Confirm", "Decline");

            if (MainResults)
            {
                try
                {
                    progress.IsVisible = true;
                    await Task.Delay(1200);
                    await App.DatabaseCon.DeleteRecipeAsync(mainMenu);
                    showMainMeals.ItemsSource = await App.DatabaseCon.GetRecipeAsync(category);
                }
                finally
                {
                    progress.IsVisible = false;
                }
            }
        }

        
    }
}