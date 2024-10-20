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
	public partial class Contenido5 : ContentPage
	{
		public Contenido5 ()
		{
			InitializeComponent ();
		}

        private void Btn_Raza(object sender, EventArgs e)
        {
            string razaText = razaEntry.Text;

            if (ContieneNumeros(razaText))
            {
                // Muestra un mensaje de error o realiza alguna acción adecuada.
                DisplayAlert("Error", "El campo 'Raza de la mascota' no puede contener números.", "OK");
            }
            else
            {
                Navigation.PushAsync(new PesodelaRaza());
            }
        }
        private bool ContieneNumeros(string texto)
        {
            return texto.Any(char.IsDigit);
        }
    }
}