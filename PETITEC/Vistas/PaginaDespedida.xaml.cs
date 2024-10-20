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
	public partial class PaginaDespedida : ContentPage
	{
		public PaginaDespedida ()
		{
			InitializeComponent ();
		}

        private void BotonFin_Clicked(object sender, EventArgs e)
        {
			Navigation.PushAsync(new MedidasCorporales());
        }
    }
}