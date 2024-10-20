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
	public partial class Contenido3 : ContentPage
	{
		public Contenido3 ()
		{
			InitializeComponent ();
		}

        private void Btn1_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Contenido4());
        }
    }
}