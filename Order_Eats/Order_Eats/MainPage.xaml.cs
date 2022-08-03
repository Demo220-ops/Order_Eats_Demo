using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Order_Eats
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void StarTers_Clicked(object sender, EventArgs e)
        {
            try
            {
                progress.IsVisible = true;
                await Task.Delay(3000);
                await Navigation.PushAsync(new FoodPages.Starters());
            }
            finally
            {
                progress.IsVisible = false;
            }
           
        }

        private async void mainsMeals_Clicked(object sender, EventArgs e)
        {
            try
            {
                progress.IsVisible = true;
                await Task.Delay(3000);
                await Navigation.PushAsync(new FoodPages.MainMeals());
            }
            finally
            {
                progress.IsVisible = false;
            }
        }

        private async void dessertDish_Clicked(object sender, EventArgs e)
        {
            try
            {
                progress.IsVisible = true;
                await Task.Delay(3000);
                await Navigation.PushAsync(new FoodPages.Desserts());
            }
            finally
            {
                progress.IsVisible = false;
            }
        }

        private async void coolDrinks_Clicked(object sender, EventArgs e)
        {
            try
            {
                progress.IsVisible = true;
                await Task.Delay(3000);
                await Navigation.PushAsync(new FoodPages.Cooldrinks());
            }
            finally
            {
                progress.IsVisible = false;
            }
        }
    }
}
