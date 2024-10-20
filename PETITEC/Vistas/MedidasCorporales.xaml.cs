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
	public partial class MedidasCorporales : ContentPage
	{
		public MedidasCorporales ()
		{
			InitializeComponent ();
		}

		private void BotonProto_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new graficas_de_pasos());
        }
    }
}