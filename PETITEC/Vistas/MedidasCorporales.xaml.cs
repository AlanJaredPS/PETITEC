using PETITEC.Models;
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
			CargarDatosMascota();
		}

		private void CargarDatosMascota()
		{
            if (SesionActual.UsuarioLogeado != null)
            {
                // Si ya tienes los datos guardados en la clase DatosMascota, puedes usarlos directamente
                lblTitulo.Text = $"Medidas corporales de {DatosMascota.NombreMascota}";
                lblPeso.Text = $"{DatosMascota.PesoMascota} kg";
                lblRaza.Text = DatosMascota.RazaMascota;
                lblTamaño.Text = DatosMascota.TamañoMascota;

                // Mostrar la fecha actual en cada frame
                DateTime fechaIngreso = DateTime.Now;
                lblFechaPeso.Text = fechaIngreso.ToString("dd/MMM/yyyy");
                lblFechaRaza.Text = fechaIngreso.ToString("dd/MMM/yyyy");
                lblFechaTamaño.Text = fechaIngreso.ToString("dd/MMM/yyyy");
            }
        }

        private void BotonProto_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new graficas_de_pasos());
        }

        private void GuardarMascotaEnBaseDeDatos()
        {
            if (SesionActual.UsuarioLogeado != null)
            {
                // Crear un nuevo objeto Mascota con los datos que tenemos en DatosMascota
                var nuevaMascota = new Mascota
                {
                    Nombre = DatosMascota.NombreMascota,
                    Raza = DatosMascota.RazaMascota,
                    Peso = DatosMascota.PesoMascota,
                    Tamaño = DatosMascota.TamañoMascota,  // Añadir el tamaño
                    UsuarioId = SesionActual.UsuarioLogeado.Id // Asociar la mascota con el usuario que inició sesión
                };

                // Guardar en la base de datos
                SQlite.DatosMascota(nuevaMascota);

                DisplayAlert("Éxito", "Los datos de la mascota se guardaron correctamente.", "OK");
            }
            else
            {
                DisplayAlert("Error", "No se ha iniciado sesión.", "OK");
            }
        }
    }
}