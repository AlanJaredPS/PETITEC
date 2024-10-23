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
	public partial class Crear_Cuenta : ContentPage
	{
		public Crear_Cuenta ()
		{
			InitializeComponent ();
		}
        private void BtnCrearCuenta_Clicked(object sender, EventArgs e)
        {
            // Obtener datos ingresados
            string nombre = entryNombre.Text;
            string correo = entryCorreo.Text;
            string password = entryPassword.Text;

            // Lógica de creación de cuenta
            if (!string.IsNullOrEmpty(nombre) && !string.IsNullOrEmpty(correo) && !string.IsNullOrEmpty(password))
            {
                // Aquí puedes manejar el registro, como guardar los datos en una base de datos
                DisplayAlert("Cuenta creada", "¡Cuenta creada con éxito!", "OK");
                Navigation.PushAsync(new Menuprincipal()); // Redirige al menú principal u otra página
            }
            else
            {
                DisplayAlert("Error", "Por favor ingrese todos los campos", "OK");
            }
        }
    }
}