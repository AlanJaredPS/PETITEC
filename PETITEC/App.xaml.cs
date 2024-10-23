using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PETITEC.Vistas;
using PETITEC.Models;

namespace PETITEC
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Menuprincipal());
            App.Current.UserAppTheme = OSAppTheme.Light;

            //Aqui colocaremos el comando a la base de datos

            new SQlite();
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
