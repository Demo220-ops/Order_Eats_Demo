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
    public partial class AddUsers : ContentPage
    {
        public AddUsers()
        {
            InitializeComponent();
        }

        Users _userData;
        public AddUsers(Users user)
        {
            InitializeComponent();
            Title = "Edit User";
            _userData = user;
            userName.Text = user.FirstName;
            userSurname.Text = user.SurName;
            email.Text = user.Email;
            userPwd.Text = user.Password;
            userPhone.Text = user.CellPhone;
            userName.Focus();
        }

        private async void Add_User(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(userName.Text) && string.IsNullOrWhiteSpace(userSurname.Text) && string.IsNullOrWhiteSpace(email.Text) && string.IsNullOrWhiteSpace(userPwd.Text) && string.IsNullOrWhiteSpace(userPhone.Text))
            {
                await DisplayAlert("Info", "No User Info Provided", "Cancel");
            }
            else if(string.IsNullOrWhiteSpace(userName.Text))
            {
                await DisplayAlert("Info", "No User name Provided", "Cancel");
            }
            else if(string.IsNullOrWhiteSpace(userSurname.Text))
            {
                await DisplayAlert("Info", "No Surname Provided", "Cancel");
            }
            else if(string.IsNullOrWhiteSpace(email.Text))
            {
                await DisplayAlert("Info", "No Email Provided", "Cancel");
            }
            else if(string.IsNullOrWhiteSpace(userPwd.Text))
            {
                await DisplayAlert("Info", "No Password Entered", "Cancel");
            }
            else if(string.IsNullOrWhiteSpace(userPhone.Text))
            {
                await DisplayAlert("Info", "No Phonenumber Entered", "Cancel");
            }
            else if(_userData != null)
            {
                UpdateUser();
            }
            else
            {
                _ = await App.DatabaseCon.SaveUserAsync(new Users { FirstName = userName.Text, SurName = userSurname.Text, Email = email.Text, Password = userPwd.Text, CellPhone = userPhone.Text });

                userName.Text = string.Empty;
                userSurname.Text = string.Empty;
                
                email.Text = string.Empty;
                userPwd.Text = string.Empty;
                userPhone.Text = string.Empty;
                progress.IsVisible = true;
                await Task.Delay(800);
                await Navigation.PopAsync();
            }

            async void UpdateUser()
            {
                _userData.FirstName = userName.Text;
                _userData.SurName = userSurname.Text;
                _userData.Email = email.Text;
                _userData.Password = userPwd.Text;
                _userData.CellPhone = userPhone.Text;

                progress.IsVisible = true;
                await Task.Delay(1500);
                await App.DatabaseCon.UpdateUserAsync(_userData);
                await Navigation.PopAsync();
            }
        }

    }
}