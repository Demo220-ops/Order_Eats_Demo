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
    public partial class Cooldrinks : ContentPage
    {
        string category = "Cooldrinks";
        public Cooldrinks()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            showCooldrinks.ItemsSource = await App.DatabaseCon.GetRecipeAsync(category);
        }

        async void addCooldrinks_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RecipePages.AddCooldrinks());
        }

        async void Edit_swipe(object sender, EventArgs e)
        {
            var cooldrinkMenu = sender as SwipeItem;
            var coolMenu = cooldrinkMenu.CommandParameter as MenuItems;
            await Navigation.PushAsync(new RecipePages.AddCooldrinks(coolMenu));
        }

        async void Delete_swipe(object sender, EventArgs e)
        {
            var cooldrinkMenu = sender as SwipeItem;
            var coolMenu = cooldrinkMenu.CommandParameter as MenuItems;
            var coolResults = await DisplayAlert("Delete", "Are you sure you want to delete your recipe", "Confirm", "Decline");

            if(coolResults)
            {
                try
                {
                    progress.IsVisible = true;
                    await Task.Delay(1300);
                    await App.DatabaseCon.DeleteRecipeAsync(coolMenu);
                    showCooldrinks.ItemsSource = await App.DatabaseCon.GetRecipeAsync(category);
                }
                finally
                {
                    progress.IsVisible = false;
                }
            }
           
        }
    }
}