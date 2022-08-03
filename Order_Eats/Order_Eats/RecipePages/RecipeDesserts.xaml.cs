using Order_Eats.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Order_Eats.RecipePages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipeDesserts : ContentPage
    {
        public RecipeDesserts()
        {
            InitializeComponent();
        }

        MenuItems _dessertMenu;
        public RecipeDesserts(MenuItems dessertItem)
        {
            InitializeComponent();

            Title = "Edit Dessert";
            _dessertMenu = dessertItem;
            dessertName.Text = _dessertMenu.DishName;
            dessertDescription.Text = _dessertMenu.Description;
            dessertCategory.Text = _dessertMenu.category;
            dessertPrice.Text = _dessertMenu.DishPrice;
            dessertName.Focus();

        }

        async void Add_dessert(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(dessertName.Text) && string.IsNullOrWhiteSpace(dessertDescription.Text) && string.IsNullOrWhiteSpace(dessertCategory.Text) && string.IsNullOrWhiteSpace(dessertPrice.Text))
            {
                await DisplayAlert("No Info","Please fill in all fields","Cancel");
            }
            else if(string.IsNullOrWhiteSpace(dessertName.Text))
            {
                await DisplayAlert("No Dish Name", "Please Provide a name for the dish", "Cancel");
            }
            else if(string.IsNullOrWhiteSpace(dessertDescription.Text))
            {
                await DisplayAlert("No Dish Description", "Please Provide a description of your dish", "Cancel");
            }
            else if(string.IsNullOrWhiteSpace(dessertCategory.Text))
            {
                await DisplayAlert("No Dish Category", "Please fill in category", "Cancel");
                if (string.IsNullOrWhiteSpace(dessertCategory.Text))
                {
                    await DisplayAlert("No capitals", "Please type dessert with a capital", "Cancel");
                }
            }
            else if(string.IsNullOrWhiteSpace(dessertPrice.Text))
            {
                await DisplayAlert("No Price", "Please provide a price", "Cancel");
            }
            else if(_dessertMenu != null)
            {
                UpdateDessertRecipe();
            }
            else
            {
                _ = await App.DatabaseCon.SaveRecipeAsync(new MenuItems { DishName = dessertName.Text, Description = dessertDescription.Text, category = dessertCategory.Text, DishPrice = dessertPrice.Text });

                dessertName.Text = string.Empty;
                dessertDescription.Text = string.Empty;
                dessertCategory.Text = string.Empty;
                dessertPrice.Text = string.Empty;

                await Task.Delay(800);
                await Navigation.PopAsync();
            }

            //Update function
            async void UpdateDessertRecipe()
            {
                _dessertMenu.DishName = dessertName.Text;
                _dessertMenu.Description = dessertDescription.Text;
                _dessertMenu.category = dessertCategory.Text;
                _dessertMenu.DishPrice = dessertPrice.Text;

                progress.IsVisible = true;
                await Task.Delay(1500);
                await App.DatabaseCon.UpdateRecipeAsync(_dessertMenu);
                await Navigation.PopAsync();
            }

        }
    }
}