using Order_Eats.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Order_Eats
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        async void Login_App(object sender, EventArgs e)
        {
            string Email = email.Text;
            string Pass = pass.Text;

            if(!string.IsNullOrWhiteSpace(Email))
            {
                if(!string.IsNullOrWhiteSpace(Pass))
                {
                    if(Email == "Admin")
                    {
                        if(Pass == "123456")
                        {
                            try
                            {
                                progress.IsVisible = true;
                                await Task.Delay(3000);
                                await Navigation.PushAsync(new MainPage());
                            }
                            finally
                            {
                                progress.IsVisible = false;
                            }
                        }
                        else
                        {
                            await DisplayAlert("Info", "Incorrect Password", "cancel");
                        }
                    }
                    else
                    {
                        await DisplayAlert("Info", "Incorrect Username", "cancel");
                    }
                }
                else
                {
                    await DisplayAlert("Info","No password provided","cancel");
                }
            }
            else
            {
                await DisplayAlert("Info","No Username Provided","cancel");
            }
        }

        async void Register_Here(object sender, EventArgs e)
        {
            try
            {
                progress.IsVisible = true;
                await Task.Delay(3000);
                await Navigation.PushAsync(new ViewUsers());
            }
            finally
            {
                progress.IsVisible = false;
            }
        }
    }
}