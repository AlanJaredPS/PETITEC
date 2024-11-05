using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PETITEC.Models;

namespace PETITEC.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Crear_Cuenta : ContentPage
    {
        public Crear_Cuenta()
        {
            InitializeComponent();
        }
        private void BtnCrearCuenta_Clicked(object sender, EventArgs e)
        {
            // Obtener datos ingresados
            string nombre = entryNombre.Text;
            string correo = entryCorreo.Text;
            string password = entryPassword.Text;

            // Lógica de creación de cuenta
            if (!string.IsNullOrEmpty(nombre) && !string.IsNullOrEmpty(correo) && !string.IsNullOrEmpty(password))
            {
                var usuarioExistente = SQlite.GetUsuarioPorCorreo(correo);
                if (usuarioExistente == null)
                {
                    var nuevoUsuario = new Usuario
                    {
                        Nombre = nombre,
                        Correo = correo,
                        Contraseña = password,
                        FechaRegistro = DateTime.Now
                    };

                    SQlite.SaveUsuario(nuevoUsuario);

                    DisplayAlert("Cuenta creada", "¡Cuenta creada con éxito!", "OK");
                    Navigation.PushAsync(new Menuprincipal());

                }
                else
                {
                    DisplayAlert("Error", "El correo ya está registrado. Por favor, use otro correo.", "OK");
                }
            }
            else
            {
                DisplayAlert("Error", "Por favor ingrese todos los campos", "OK");
            }
        }
    }
}