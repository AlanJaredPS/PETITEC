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
	public partial class NombreMascota : ContentPage
	{
		public NombreMascota ()
		{
			InitializeComponent ();
		}

        // Validar que solo se ingresen letras
        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = sender as Entry;

            // Filtrar caracteres no alfabéticos (quitar números y símbolos)
            string textoFiltrado = new string(e.NewTextValue.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)).ToArray());

            if (entry.Text != textoFiltrado)
            {
                entry.Text = textoFiltrado; // Actualizar el campo de texto con solo letras
            }
        }

        // Lógica del botón Continuar
        private void Btn_Nombre_Clicked(object sender, EventArgs e)
        {
            string nombre = nombreEntry.Text; // Obtener el nombre ingresado

            if (!string.IsNullOrEmpty(nombre)) // Verificar que el campo no esté vacío
            {
                DisplayAlert("Nombre ingresado", $"El nombre de tu mascota es: {nombre}", "OK");

                Navigation.PushAsync(new Paseos());
            }
            else
            {
                DisplayAlert("Error", "Por favor, ingrese el nombre de su mascota", "OK");
            }
        }
    }
}