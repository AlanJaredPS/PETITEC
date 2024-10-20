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
	public partial class GolpeCalor : ContentPage
	{
        private Button selectedButton;
        public GolpeCalor ()
		{
			InitializeComponent ();
		}

        private void btnNo_Clicked(object sender, EventArgs e)
        {
            UpdateButtonState(btnNo);
        }

        private void btnSi_Clicked(object sender, EventArgs e)
        {
            UpdateButtonState(btnSi);
        }

        private void BotonContinuar_Clicked(object sender, EventArgs e)
        {
            if(selectedButton != null)
            {
                Navigation.PushAsync(new Ansiedad());
            }
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