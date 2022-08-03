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
    public partial class AddCooldrinks : ContentPage
    {
        public AddCooldrinks()
        {
            InitializeComponent();
        }

        MenuItems _cooldrinkItem;
        public AddCooldrinks(MenuItems coolItem)
        {
            InitializeComponent();

            Title = "Edit Cooldrink";
            _cooldrinkItem = coolItem;
            cooldrinkName.Text = coolItem.DishName;
            cooldrinkDescription.Text = coolItem.Description;
            cooldrinkCategory.Text = coolItem.category;
            cooldrinkPrice.Text = coolItem.DishPrice;
            cooldrinkName.Focus();
        }
        async void Add_cooldrink(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(cooldrinkName.Text) && string.IsNullOrWhiteSpace(cooldrinkDescription.Text) && string.IsNullOrWhiteSpace(cooldrinkCategory.Text) && string.IsNullOrWhiteSpace(cooldrinkPrice.Text))
            {
                await DisplayAlert("Info","No info Provided","Cancel");
            }
            else if(string.IsNullOrWhiteSpace(cooldrinkName.Text))
            {
                await DisplayAlert("Info", "Provide a name for dish", "Cancel");
            }
            else if(string.IsNullOrWhiteSpace(cooldrinkDescription.Text))
            {
                await DisplayAlert("Info", "Provide a description", "Cancel");
            }
            else if(string.IsNullOrWhiteSpace(cooldrinkCategory.Text))
            {
                await DisplayAlert("Info", "Please Type Cooldrinks with a capital letter", "Cancel");
            }
            else if(string.IsNullOrWhiteSpace(cooldrinkPrice.Text))
            {
                await DisplayAlert("Info", "Please provide a price", "Cancel");
            }
            else if(_cooldrinkItem != null)
            {
                UpdateCooldrinks();
            }
            else
            {
                _ = await App.DatabaseCon.SaveRecipeAsync(new MenuItems { DishName = cooldrinkName.Text, Description = cooldrinkDescription.Text, category = cooldrinkCategory.Text, DishPrice = cooldrinkPrice.Text});

                cooldrinkName.Text = string.Empty;
                cooldrinkDescription.Text = string.Empty;
                cooldrinkCategory.Text = string.Empty;
                cooldrinkPrice.Text = string.Empty;
                progress.IsVisible = true;
                await Task.Delay(800);
                await Navigation.PopAsync();
            }

            //Update Method
            async void UpdateCooldrinks()
            {
                _cooldrinkItem.DishName = cooldrinkName.Text;
                _cooldrinkItem.Description = cooldrinkDescription.Text;
                _cooldrinkItem.category = cooldrinkCategory.Text;
                _cooldrinkItem.DishPrice = cooldrinkPrice.Text;

                progress.IsVisible = true;
                await Task.Delay(1500);
                await App.DatabaseCon.UpdateRecipeAsync(_cooldrinkItem);
                await Navigation.PopAsync();
            }
            
        }
    }
}