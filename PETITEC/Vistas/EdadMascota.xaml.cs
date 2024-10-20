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
	public partial class EdadMascota : ContentPage
	{
        private Button selectedButton;

        public EdadMascota ()
		{
			InitializeComponent ();
		}

        private void btn6Meses_Clicked(object sender, EventArgs e)
        {
            UpdateButtonState(btn6Meses);
        }

        private void btn12Meses_Clicked(object sender, EventArgs e)
        {
            UpdateButtonState(btn12Meses);
        }

        private void btn7años_Clicked(object sender, EventArgs e)
        {
            UpdateButtonState(btn7años);
        }

        private void btn7añosMas_Clicked(object sender, EventArgs e)
        {
            UpdateButtonState(btn7añosMas);
        }

        private void btn2años_Clicked(object sender, EventArgs e)
        {
            UpdateButtonState(btn2años);
        }

        private void BotonContinuar_Clicked(object sender, EventArgs e)
        {
            // Acciones cuando se hace clic en "Continuar"
            if (selectedButton != null)
            {
                Navigation.PushAsync(new SaludMascota());
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