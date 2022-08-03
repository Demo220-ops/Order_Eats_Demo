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
    public partial class RecipeMainMeals : ContentPage
    {
        public RecipeMainMeals()
        {
            InitializeComponent();
        }

        MenuItems _mainMenu;
        public RecipeMainMeals(Data.MenuItems mainMenu)
        {
            InitializeComponent();

            Title = "Edit Main Meals Recipy";
            _mainMenu = mainMenu;
            MaindishName.Text = mainMenu.DishName;
            MaindishDescription.Text = mainMenu.Description;
            MaindishCategory.Text = mainMenu.category;
            MaindishPrice.Text = mainMenu.DishPrice;
            MaindishName.Focus();
        }

        private async void Add_Mains(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(MaindishName.Text) && string.IsNullOrWhiteSpace(MaindishDescription.Text) && string.IsNullOrWhiteSpace(MaindishCategory.Text) && string.IsNullOrWhiteSpace(MaindishPrice.Text))
            {
                await DisplayAlert("Incorrect Details","Please Fill In all Fields"," Cancel");
            }
            else if(string.IsNullOrWhiteSpace(MaindishName.Text))
            {
                await DisplayAlert("Info","No dish name provided","Cancel");
            }
            else if(string.IsNullOrWhiteSpace(MaindishDescription.Text))
            {
                await DisplayAlert("Info","Please Provide a dish description","Cancel");
            }
            else if(string.IsNullOrWhiteSpace(MaindishCategory.Text))
            {
                await DisplayAlert("Info","Please type main meal with capitals","cancel");
            }
            else if(string.IsNullOrWhiteSpace(MaindishPrice.Text))
            {
                await DisplayAlert("Info","Please provide a price","Cancel");
            }
            else if(_mainMenu != null)
            {
                //Calling the update method
                UpdateRecipe();
            }
            else
            {
                //Adding the recipy after validation
                _ = await App.DatabaseCon.SaveRecipeAsync(new MenuItems { DishName = MaindishName.Text, Description = MaindishCategory.Text, category = MaindishCategory.Text, DishPrice = MaindishPrice.Text });

                MaindishName.Text = string.Empty;
                MaindishDescription.Text = string.Empty;
                MaindishCategory.Text = string.Empty;
                MaindishPrice.Text = string.Empty;
                progress.IsVisible = true;
                await Task.Delay(1300);
                await Navigation.PopAsync();

            }

            //Update method 
            async void UpdateRecipe()
            {
                _mainMenu.DishName = MaindishName.Text;
                _mainMenu.Description = MaindishDescription.Text;
                _mainMenu.category = MaindishCategory.Text;
                _mainMenu.DishPrice = MaindishPrice.Text;

                progress.IsVisible = true;
                await Task.Delay(1300);
                await App.DatabaseCon.UpdateRecipeAsync(_mainMenu);
                await Navigation.PopAsync();
            }
        }
    }
}