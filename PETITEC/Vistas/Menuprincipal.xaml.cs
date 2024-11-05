using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PETITEC.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menuprincipal : ContentPage
    {
        public Menuprincipal()
        {
            InitializeComponent();
        }
        // Lógica para el botón de "Iniciar Sesión"
        private void btnIniciarSesion_Clicked(object sender, EventArgs e)
        {
            // Aquí navegas a la página de inicio de sesión
            Navigation.PushAsync(new Inicio_de_sesion());
        }

        // Lógica para el botón de "Crear Cuenta"
        private void btnCrearCuenta_Clicked(object sender, EventArgs e)
        {
            // Aquí navegas a la página de registro
            Navigation.PushAsync(new Crear_Cuenta());
        }
    }
}