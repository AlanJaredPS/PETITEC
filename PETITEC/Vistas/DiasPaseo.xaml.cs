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
	public partial class DiasPaseo : ContentPage
	{
        private Button selectedButton;

        public DiasPaseo ()
		{
			InitializeComponent ();
		}

        // Cuando se selecciona "Diario"
        private void BtnDiario_Clicked(object sender, EventArgs e)
        {
            UpdateButtonState(btnDiario); // Selección del botón "Diario"
        }

        // Cuando se selecciona "Cada 3er día"
        private void BtnCada3erDia_Clicked(object sender, EventArgs e)
        {
            UpdateButtonState(btnCada3erDia); // Selección del botón "Cada 3er día"
        }

        // Cuando se selecciona "1 vez por semana"
        private void Btn1vezPorSemana_Clicked(object sender, EventArgs e)
        {
            UpdateButtonState(btn1vezPorSemana); // Selección del botón "1 vez por semana"
        }

        // Lógica del botón Continuar
        private void Btn_Continuar_Clicked(object sender, EventArgs e)
        {
            if (selectedButton != null)
            {
                Navigation.PushAsync(new Kilometros());
            }
        }

        // Método para actualizar el estado del botón seleccionado
        private void UpdateButtonState(Button selectedBtn)
        {
            // Cambiar el estado del botón seleccionado
            if (selectedButton != null)
            {
                selectedButton.BackgroundColor = Color.FromHex("#00FFFFFF"); // Restablecer el color del botón anterior
            }

            selectedBtn.BackgroundColor = Color.Gold; // Resaltar el botón seleccionado
            selectedButton = selectedBtn; // Guardar el botón seleccionado

            // Mostrar el botón "Continuar" solo cuando se selecciona una opción
            btnContinuar.IsVisible = selectedButton != null;
        }
    }
}