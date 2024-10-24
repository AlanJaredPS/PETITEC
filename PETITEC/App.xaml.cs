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

            // Inicializar la base de datos
            new SQlite();

            // Verificar si el usuario ya ha iniciado sesión
            bool isLoggedIn = Xamarin.Essentials.Preferences.Get("IsLoggedIn", false);
            bool hasCompletedRegistration = Xamarin.Essentials.Preferences.Get("HasCompletedRegistration", false);

            // Lógica para redirigir al usuario a la pantalla correcta según el estado de la sesión
            if (isLoggedIn)
            {
                if (hasCompletedRegistration)
                {
                    // Si ya ha completado el registro de su mascota, redirigir a la pantalla principal (por ejemplo, a GraficasPasos)
                    MainPage = new NavigationPage(new graficas_de_pasos()); // O la pantalla principal que quieras mostrar
                }
                else
                {
                    // Si aún no ha completado el registro de la mascota, redirigir al flujo de registro de la mascota
                    MainPage = new NavigationPage(new Contenido5());
                }
            }
            else
            {
                // Si no ha iniciado sesión, redirigir al Menuprincipal donde puede elegir iniciar sesión o crear cuenta
                MainPage = new NavigationPage(new Menuprincipal());
            }

            // Configurar el tema de la app
            App.Current.UserAppTheme = OSAppTheme.Light;
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
