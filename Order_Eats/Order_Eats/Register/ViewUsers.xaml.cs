using Order_Eats.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Order_Eats.Register
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewUsers : ContentPage
    {
        public ViewUsers()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ShowUsers.ItemsSource = await App.DatabaseCon.GetUserAsync();
        }

        async void addUsers_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddUsers());
        }

        //Edit the swiped item
        async void Edit_swipe(object sender, EventArgs e)
        {
            var users = sender as SwipeItem;
            var userData = users.CommandParameter as Users;
            await Navigation.PushAsync(new AddUsers(userData)); 
        }

        //Delete the swiped item
        async void Delete_swipe(object sender, EventArgs e)
        {
            var users = sender as SwipeItem;
            var userData = users.CommandParameter as Users;
            var userResults = await DisplayAlert("Delete", "Are you sure you want to delete your Profile", "Confirm", "Decline");

            if(userResults)
            {
                try
                {
                    progress.IsVisible = true;
                    await Task.Delay(1300);
                    await App.DatabaseCon.DeleteUserAsync(userData);
                    ShowUsers.ItemsSource = await App.DatabaseCon.GetUserAsync();
                }
                finally
                {
                    progress.IsVisible = false;
                }
               
            }


        }
    }
}