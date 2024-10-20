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
	public partial class Kilometros : ContentPage
	{
		public Kilometros ()
		{
			InitializeComponent ();
		}

        private void Btn_Kilometros(object sender, EventArgs e)
        {
            string kilometros = kilometrosEntry.Text; // Obtener los kilómetros ingresados

            if (!string.IsNullOrEmpty(kilometros)) // Verificar que el campo no esté vacío
            {
                DisplayAlert("Kilómetros ingresados", $"Has ingresado: {kilometros} km", "OK");

                Navigation.PushAsync(new MedidasCorporales());
            }
            else
            {
                DisplayAlert("Error", "Por favor, ingrese los kilómetros recorridos", "OK");
            }
        }
    }
}