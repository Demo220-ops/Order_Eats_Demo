using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Order_Eats
{
    public partial class App : Application
    {
        private static Data.DatabaseCon db;

        public static Data.DatabaseCon DatabaseCon
        {
            get
            {
                if(db == null)
                {
                    //var path = new Data.DatabaseCon(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MenuItems.db3"));
                   db = new Data.DatabaseCon(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Recipies.db3"));
                }
                return db;
            }
        }

        public static object Database { get; internal set; }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Login());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
