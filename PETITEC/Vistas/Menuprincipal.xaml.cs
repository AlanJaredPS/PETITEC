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
    public partial class Menuprincipal : ContentPage
    {
        public Menuprincipal()
        {
            InitializeComponent();
        }

        private void btnIniciar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Explicacion());
        }
    }
}