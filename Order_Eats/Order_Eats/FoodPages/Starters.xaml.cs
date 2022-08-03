using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Order_Eats.Data;

namespace Order_Eats.FoodPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Starters : ContentPage
    {
        string category = "Starter";
        public Starters()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            showStarter.ItemsSource = await App.DatabaseCon.GetRecipeAsync(category);
        }

        private async void addStarter_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RecipePages.RecipeStarters());
        }

        //Edit Item
        async void SwipeItem_Invoked(object sender, EventArgs e)
        {
            var menuitem = sender as SwipeItem;
            var menu = menuitem.CommandParameter as MenuItems;
            await Navigation.PushAsync(new RecipePages.RecipeStarters(menu));
        }

        //Delete Item
        async void SwipeItem_Invoked_1(object sender, EventArgs e)
        {
            var menuitem = sender as SwipeItem;
            var menu = menuitem.CommandParameter as MenuItems;
            var menuResults = await DisplayAlert("Delete", "Are you sure you want to delete your recipe", "Confirm", "Decline");

            if(menuResults)
            {
                try
                {
                    progress.IsVisible = true;
                    await Task.Delay(1300);
                    await App.DatabaseCon.DeleteRecipeAsync(menu);
                    showStarter.ItemsSource = await App.DatabaseCon.GetRecipeAsync(category);
                }
                finally
                {
                    progress.IsVisible = false;
                }
                
            }
        }
    }
}