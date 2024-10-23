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
	public partial class Inicio_de_sesion : ContentPage
	{
		public Inicio_de_sesion ()
		{
			InitializeComponent ();
		}

        private void BtnIniciarSesion_Clicked(object sender, EventArgs e)
        {
            // Obtén los datos ingresados
            string emailUsuario = entryEmailUsuario.Text;
            string password = entryPassword.Text;

            // Lógica para manejar el inicio de sesión (aquí podrías agregar la autenticación)
            if (!string.IsNullOrEmpty(emailUsuario) && !string.IsNullOrEmpty(password))
            {
                // Simular autenticación o redirigir a otra página
                DisplayAlert("Inicio de sesión", "Sesión iniciada con éxito", "OK");
                Navigation.PushAsync(new Contenido2()); // Redirige al menú principal o página correspondiente
            }
            else
            {
                DisplayAlert("Error", "Por favor ingrese todos los campos", "OK");
            }
        }
    }
}