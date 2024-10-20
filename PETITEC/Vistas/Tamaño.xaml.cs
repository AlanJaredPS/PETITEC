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
        private Button botonSeleccionado = null; // Para rastrear qué botón está seleccionado

        public Tamaño ()
		{
			InitializeComponent ();
		}

        // Método para mostrar/ocultar el menú desplegable
        private void ToggleMenuVisibility(object sender, EventArgs e)
        {
            TamañoMenu.IsVisible = !TamañoMenu.IsVisible; // Cambia la visibilidad del menú
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
            button.BackgroundColor = Color.FromHex("#FFA500"); // Cambiar el fondo del botón seleccionado (naranja brillante)
            button.TextColor = Color.Black; // Cambiar el texto del botón seleccionado a negro

            botonSeleccionado = button; // Guardar el botón seleccionado

            // Habilitar el botón de continuar
            btnContinuar.IsEnabled = true;
        }

        // Método para avanzar al siguiente contenido
        private void Btn_Continuar_Clicked(object sender, EventArgs e)
        {
            // Lógica para continuar al siguiente contenido
            DisplayAlert("Avanzando", "Tamaño seleccionado: " + botonSeleccionado.Text, "OK");

            Navigation.PushAsync(new Contenido5());
        }
    }
}