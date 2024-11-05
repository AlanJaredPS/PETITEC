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
        public MedidasCorporales()
        {
            InitializeComponent();
            CargarDatosMascota();

            // Verificar si los datos de la mascota ya han sido guardados en la base de datos
            bool datosGuardados = SQlite.ObtenerMascotaPorUsuarioId(SesionActual.UsuarioLogeado.Id) != null;
            if (datosGuardados)
            {
                BotonProto.IsVisible = false;
                CargarDatosDesdeBaseDeDatos();
            }
        }

        private void CargarDatosMascota()
        {
            // Utilizar los datos temporales de DatosMascota para mostrarlos en la interfaz
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

        // Método para cargar los datos desde la base de datos si ya están guardados
        private void CargarDatosDesdeBaseDeDatos()
        {
            if (SesionActual.UsuarioLogeado != null)
            {
                // Recuperar la mascota asociada al usuario desde la base de datos
                var mascota = SQlite.ObtenerMascotaPorUsuarioId(SesionActual.UsuarioLogeado.Id);

                if (mascota != null)
                {
                    // Mostrar los datos recuperados en la interfaz
                    lblTitulo.Text = $"Medidas corporales de {mascota.Nombre}";
                    lblPeso.Text = $"{mascota.Peso} kg";
                    lblRaza.Text = mascota.Raza;
                    lblTamaño.Text = mascota.Tamaño;

                    // Actualizar la fecha de ingreso si es necesario
                    DateTime fechaIngreso = DateTime.Now;
                    lblFechaPeso.Text = fechaIngreso.ToString("dd/MMM/yyyy");
                    lblFechaRaza.Text = fechaIngreso.ToString("dd/MMM/yyyy");
                    lblFechaTamaño.Text = fechaIngreso.ToString("dd/MMM/yyyy");
                }
                else
                {
                    DisplayAlert("Error", "No se encontraron datos de la mascota.", "OK");
                }
            }
        }

        // Método para guardar los datos en la base de datos cuando se hace clic en "Guardar cambios"
        private void BotonProto_Clicked(object sender, EventArgs e)
        {
            GuardarMascotaEnBaseDeDatos();

            // Ocultar el botón después de guardar los datos
            BotonProto.IsVisible = false;

            Xamarin.Essentials.Preferences.Set("HasCompletedRegistration", true);
            DisplayAlert("Registro Completado", "El registro de la mascota se ha completado y guardado.", "OK");

            // Redirigir a la página de gráficas de pasos
            Navigation.PushAsync(new graficas_de_pasos());
        }

        private void GuardarMascotaEnBaseDeDatos()
        {
            if (SesionActual.UsuarioLogeado != null)
            {
                // Verificar si la mascota ya existe en la base de datos
                var mascotaExistente = SQlite.ObtenerMascotaPorUsuarioId(SesionActual.UsuarioLogeado.Id);

                if (mascotaExistente != null)
                {
                    // Si la mascota ya existe, actualizar sus datos
                    mascotaExistente.Nombre = DatosMascota.NombreMascota;
                    mascotaExistente.Raza = DatosMascota.RazaMascota;
                    mascotaExistente.Peso = DatosMascota.PesoMascota;
                    mascotaExistente.Tamaño = DatosMascota.TamañoMascota;

                    SQlite.UpdateMascota(mascotaExistente); // Método para actualizar la mascota
                }
                else
                {
                    // Si no existe, crear una nueva mascota
                    var nuevaMascota = new Mascota
                    {
                        Nombre = DatosMascota.NombreMascota,
                        Raza = DatosMascota.RazaMascota,
                        Peso = DatosMascota.PesoMascota,
                        Tamaño = DatosMascota.TamañoMascota,
                        UsuarioId = SesionActual.UsuarioLogeado.Id
                    };

                    SQlite.DatosMascota(nuevaMascota); // Insertar nueva mascota
                }

                // Actualizar el estado de registro de la mascota en las preferencias
                Xamarin.Essentials.Preferences.Set("DatosMascotaGuardados", true);

                DisplayAlert("Éxito", "Los datos de la mascota se guardaron correctamente.", "OK");
            }
            else
            {
                DisplayAlert("Error", "No se ha iniciado sesión.", "OK");
            }
        }
    }
}