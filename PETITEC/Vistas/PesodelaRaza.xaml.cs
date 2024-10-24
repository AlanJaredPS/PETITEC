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
	public partial class PesodelaRaza : ContentPage
	{
		public PesodelaRaza ()
		{
			InitializeComponent ();
		}

		private void Btn_Peso(object sender, EventArgs e)
		{
            string pesoText = pesoEntry.Text;

            if (!string.IsNullOrEmpty(pesoText))
            {
                double peso;
                if (double.TryParse(pesoText, out peso))
                {
                    // Guardar el peso temporalmente en DatosMascota
                    DatosMascota.PesoMascota = peso;

                    DisplayAlert("Peso ingresado", $"El peso aproximado de tu mascota es: {peso} kg", "OK");

                    Navigation.PushAsync(new NombreMascota());
                }
                else
                {
                    DisplayAlert("Error", "Por favor, ingrese un peso válido.", "OK");
                }
            }
            else
            {
                DisplayAlert("Error", "Por favor, ingrese el peso de su mascota.", "OK");
            }
        }
	}
}