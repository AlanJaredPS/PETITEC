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
	public partial class SaludMascota : ContentPage
	{
        private Button selectedButton;

        public SaludMascota ()
		{
			InitializeComponent ();
		}

        private void BotonContinuar_Clicked(object sender, EventArgs e)
        {
            // Acciones cuando se hace clic en "Continuar"
            if (selectedButton != null)
            {
                Navigation.PushAsync(new GolpeCalor());
            }
        }

        private void MascotaSana_Clicked(object sender, EventArgs e)
        {
            UpdateButtonState(MascotaSana);
        }

        private void Vista_Clicked(object sender, EventArgs e)
        {
            UpdateButtonState(Vista);
        }

        private void Oído_Clicked(object sender, EventArgs e)
        {
            UpdateButtonState(Oído);
        }

        private void Corazón_Clicked(object sender, EventArgs e)
        {
            UpdateButtonState(Corazón);
        }

        private void Digestión_Clicked(object sender, EventArgs e)
        {
            UpdateButtonState(Digestión);
        }

        private void Riñon_Clicked(object sender, EventArgs e)
        {
            UpdateButtonState(Riñon);
        }

        private void Alergias_Clicked(object sender, EventArgs e)
        {
            UpdateButtonState(Alergias);
        }

        private void Obesidad_Clicked(object sender, EventArgs e)
        {
            UpdateButtonState(Obesidad);
        }

        private void Otra_Clicked(object sender, EventArgs e)
        {
            UpdateButtonState(Otra);
        }
        private void UpdateButtonState(Button selectedBtn)
        {
            // Cambiar el estado seleccionado
            if (selectedButton != null)
            {
                selectedButton.BackgroundColor = Color.FromHex("#79CDE0");
            }

            selectedBtn.BackgroundColor = Color.Gold;
            selectedButton = selectedBtn;

            // Mostrar el botón "Continuar" solo cuando hay una opción seleccionada
            BotonContinuar.IsVisible = selectedButton != null;
        }
    }
}