using PETITEC.Models;
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

            if (!string.IsNullOrEmpty(emailUsuario) && !string.IsNullOrEmpty(password))
            {
                var UsuarioExistente = SQlite.GetUsuarioPorCorreoYContraseña(emailUsuario, password);
                if (UsuarioExistente != null)
                {

                    SesionActual.UsuarioLogeado = UsuarioExistente;

                    // Guardar la sesión activa en las preferencias
                    Xamarin.Essentials.Preferences.Set("IsLoggedIn", true);
                    Xamarin.Essentials.Preferences.Set("UsuarioId", UsuarioExistente.Id);

                    //si el usuario ya existe, se hace la autenticación exitosa
                    DisplayAlert("Inicio de sesión", $"Bienvenido, {UsuarioExistente.Nombre}", "OK");
                    Navigation.PushAsync(new Contenido2());
                }
                else 
                {
                    // Si el usuario no existe o la contraseña es incorrecta
                    DisplayAlert("Error", "Correo o contraseña incorrectos", "OK");
                }
            }
            else
            {
                DisplayAlert("Error", "Por favor ingrese todos los campos", "OK");
            }
        }
    }
}