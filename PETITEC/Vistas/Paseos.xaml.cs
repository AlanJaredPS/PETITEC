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
	public partial class Paseos : ContentPage
	{

        private Button selectedButton;

        public Paseos ()
		{
			InitializeComponent ();
		}

		private void BtnSi_Clicked(object sender, EventArgs e)
		{
            UpdateButtonState(btnSi);
		}

		private void BtnNo_Clicked(object sender, EventArgs e) 
		{
            UpdateButtonState(btnNo);
		}

        private void Btn_Continuar_Clicked(object sender, EventArgs e)
        {
            // Acciones cuando se hace clic en "Continuar"
            if (selectedButton != null)
            {
                Navigation.PushAsync(new DiasPaseo());
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
            btnContinuar.IsVisible = selectedButton != null;
        }
    }
}