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
    public partial class Desserts : ContentPage
    {
        string category = "Dessert";
        public Desserts()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            showDesserts.ItemsSource = await App.DatabaseCon.GetRecipeAsync(category);
        }

        private async void add_Dessert(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RecipePages.RecipeDesserts());
        }

        async void Edit_swipe(object sender, EventArgs e)
        {
            var dessertItem = sender as SwipeItem;
            var dessertMenu = dessertItem.CommandParameter as MenuItems;
            await Navigation.PushAsync(new RecipePages.RecipeDesserts(dessertMenu));
        }

        async void Delete_swipe(object sender, EventArgs e)
        {
            var dessertItem = sender as SwipeItem;
            var dessertMenu = dessertItem.CommandParameter as MenuItems;
            var dessertResults = await DisplayAlert("Delete", "Are you sure you want to delete your recipe", "Confirm", "Decline");

            if (dessertResults)
            {
                try
                {
                    progress.IsVisible = true;
                    await Task.Delay(800);
                    await App.DatabaseCon.DeleteRecipeAsync(dessertMenu);
                    showDesserts.ItemsSource = await App.DatabaseCon.GetRecipeAsync(category);
                }
                finally
                {
                    progress.IsVisible = false;
                }


            }
        }
    }
}