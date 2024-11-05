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
	public partial class Tamaño : ContentPage
	{
        private Button botonSeleccionado = null;

        public Tamaño ()
		{
			InitializeComponent ();
		}

        private void ToggleMenuVisibility(object sender, EventArgs e)
        {
            TamañoMenu.IsVisible = !TamañoMenu.IsVisible; 
        }

        // Método cuando se selecciona una opción de tamaño
        private void OnTamañoSeleccionado(object sender, EventArgs e)
        {
            var button = (Button)sender;

            // Restablecer el estilo del botón previamente seleccionado
            if (botonSeleccionado != null)
            {
                botonSeleccionado.BackgroundColor = Color.FromHex("#FFD700"); // Fondo amarillo
                botonSeleccionado.TextColor = Color.White; // Texto blanco
            }

            // Resaltar el botón seleccionado
            button.BackgroundColor = Color.FromHex("#FFA500");
            button.TextColor = Color.Black; 

            botonSeleccionado = button; // Guardar el botón seleccionado

            // Habilitar el botón de continuar
            btnContinuar.IsEnabled = true;
        }

        // Método para avanzar al siguiente contenido
        private void Btn_Continuar_Clicked(object sender, EventArgs e)
        {
            if (botonSeleccionado != null)
            {

                // Guardar el tamaño seleccionado temporalmente en DatosMascota
                DatosMascota.TamañoMascota = botonSeleccionado.Text;

                // Mostrar confirmación
                DisplayAlert("Avanzando", "Tamaño seleccionado: " + DatosMascota.TamañoMascota, "OK");

                // Navegar a la siguiente página
                Navigation.PushAsync(new Contenido5());
            }
        }
    }
}