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

            // Inicializar Google Fit
            var googleFitService = DependencyService.Get<IGoogleFitService>();
            googleFitService?.InitializeGoogleFit();

            // Verificar si el usuario ya ha iniciado sesión
            bool isLoggedIn = Xamarin.Essentials.Preferences.Get("IsLoggedIn", false);
            bool hasCompletedRegistration = Xamarin.Essentials.Preferences.Get("HasCompletedRegistration", false);

            // Lógica de navegación
            if (isLoggedIn)
            {
                int usuarioId = Xamarin.Essentials.Preferences.Get("UsuarioId", -1);
                var usuarioLogeado = SQlite.GetUsuario(usuarioId);
                SesionActual.UsuarioLogeado = usuarioLogeado;

                if (hasCompletedRegistration)
                {
                    var carouselPage = new CarouselPage
                    {
                        Children =
                    {
                        new graficas_de_pasos(), // Primera página (Gráficas de pasos)
                        new MedidasCorporales()   // Segunda página (Medidas Corporales)
                    }
                    };
                    MainPage = carouselPage;
                }
                else
                {
                    MainPage = new NavigationPage(new Contenido5());
                }
            }
            else
            {
                MainPage = new NavigationPage(new Menuprincipal());
            }

            App.Current.UserAppTheme = OSAppTheme.Light;
        }
    }
}
