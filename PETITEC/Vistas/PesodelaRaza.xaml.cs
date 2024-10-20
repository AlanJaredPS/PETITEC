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
	public partial class PesodelaRaza : ContentPage
	{
		public PesodelaRaza ()
		{
			InitializeComponent ();
		}

		private void Btn_Peso(object sender, EventArgs e)
		{
            string peso = pesoEntry.Text; // Obtener el peso ingresado

            if (!string.IsNullOrEmpty(peso))
            {
                DisplayAlert("Peso ingresado", $"El peso aproximado de tu mascota es: {peso} kg", "OK");

                Navigation.PushAsync(new NombreMascota());
            }
            else
            {
                DisplayAlert("Error", "Por favor, ingrese el peso de su mascota", "OK");
            }
		}
	}
}