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
    public partial class RecipeStarters : ContentPage
    {
        public RecipeStarters()
        {
            InitializeComponent();
        }

        //new contructor to change page from add to edit
        MenuItems _menu;
        public RecipeStarters(MenuItems menus)
        {
            InitializeComponent();
            Title = "Edit Recipy";
            _menu = menus;
            dishName.Text = menus.DishName;
            dishDescription.Text = menus.Description;
            dishCategory.Text = menus.category;
            dishPrice.Text = menus.DishPrice;
            dishName.Focus();

        }

        //Validation to make sure all fields are filled in then execute given functions
        async void Add_Starter(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(dishName.Text))
            {
                await DisplayAlert("Info","No Info Provided", "Cancel");
            }
            else if(_menu != null)
            {
                //Calling and running the update function
                UpdateRecipe();
            }
            else
            {
                // adding the recipe
                _ = await App.DatabaseCon.SaveRecipeAsync(new MenuItems { DishName = dishName.Text, Description = dishDescription.Text, category = dishCategory.Text, DishPrice = dishPrice.Text });

                dishName.Text = string.Empty;
                dishDescription.Text = string.Empty;
                dishCategory.Text = string.Empty;
                dishPrice.Text = string.Empty;
                progress.IsVisible = true;
                await Task.Delay(800);
                await Navigation.PopAsync();
            }

            //Update method
            async void UpdateRecipe()
            {
                _menu.DishName = dishName.Text;
                _menu.Description = dishDescription.Text;
                _menu.category = dishCategory.Text;
                _menu.DishPrice = dishPrice.Text;

                progress.IsVisible = true;
                await Task.Delay(1500);
                await App.DatabaseCon.UpdateRecipeAsync(_menu);
                await Navigation.PopAsync();
            }
        }
    }
}