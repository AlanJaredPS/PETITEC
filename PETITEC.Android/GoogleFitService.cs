using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Fitness.v1;
using Google.Apis.Services;
using Xamarin.Essentials;

namespace PETITEC.Droid
{
    public class GoogleFitService : IGoogleFitService
    {
        private static FitnessService _fitnessService;
        private bool _isAuthenticated;

        // Inicializar Google Fit
        public async Task InitializeGoogleFit()
        {
            if (_fitnessService != null) // Verificar si ya está inicializado
                return;

            try
            {
                // Cargar el archivo credentials.json desde Assets
                var credentialsStream = Android.App.Application.Context.Assets.Open("credentials.json");
                var googleCredential = GoogleCredential.FromStream(credentialsStream)
                    .CreateScoped(FitnessService.Scope.FitnessActivityRead, FitnessService.Scope.FitnessActivityWrite);

                _fitnessService = new FitnessService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = googleCredential,
                    ApplicationName = "PETITEC",
                });

                _isAuthenticated = true;
                Console.WriteLine("Google Fit fue inicializado correctamente");
            }
            catch (Exception ex)
            {
                _isAuthenticated = false;
                Console.WriteLine("Error al inicializar Google Fit: " + ex.Message);
            }
        }

        // Verificar si Google Fit está autenticado
        public Task<bool> IsAuthenticatedAsync()
        {
            return Task.FromResult(_isAuthenticated);
        }

        // Método para autenticar y guardar el token si aún no está autenticado
        public async Task<bool> AuthenticateAndSaveToken()
        {
            await InitializeGoogleFit(); // Intentar inicializar
            return _isAuthenticated;
        }

        // Método opcional para obtener el servicio de Google Fit ya autenticado
        public FitnessService GetFitnessService()
        {
            if (_isAuthenticated)
                return _fitnessService;
            else
                throw new InvalidOperationException("Google Fit no está autenticado");
        }
    }
}