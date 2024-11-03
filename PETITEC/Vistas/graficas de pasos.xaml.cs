using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microcharts;
using SkiaSharp;
using PETITEC.Models;

namespace PETITEC.Vistas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class graficas_de_pasos : ContentPage
    {
        private readonly IGoogleFitService googleFitService;

        public graficas_de_pasos()
        {
            InitializeComponent();
            googleFitService = DependencyService.Get<IGoogleFitService>();

            // Asegurar que Google Fit esté autenticado y luego cargar los gráficos
            EnsureGoogleFitConnectionAndLoadCharts();
        }

        private async void EnsureGoogleFitConnectionAndLoadCharts()
        {
            // Verificar si Google Fit ya está inicializado
            bool isAuthenticated = googleFitService != null && await googleFitService.IsAuthenticatedAsync();

            if (!isAuthenticated)
            {
                // Si no está autenticado, autenticar y guardar el token
                bool authSuccess = await googleFitService?.AuthenticateAndSaveToken();
                if (!authSuccess)
                {
                    // Mostrar un mensaje si la autenticación falla
                    await DisplayAlert("Error", "No se pudo conectar a Google Fit", "OK");
                    return;
                }
            }

            // Una vez autenticado, cargar los gráficos
            LoadCharts();
        }

        private void LoadCharts()
        {
            // Datos obtenidos de la base de datos para cada período
            var pasosHoy = ObtenerPasos("Diario");
            var pasosSemana = ObtenerPasos("Semanal");
            var pasosMes = ObtenerPasos("Mensual");

            var distanciaHoy = ObtenerDistancia("Diario");
            var distanciaSemana = ObtenerDistancia("Semanal");
            var distanciaMes = ObtenerDistancia("Mensual");

            // Gráfico de pasos para día, semana, mes
            StepCountChartDia.Chart = new DonutChart
            {
                Entries = new[]
                {
                new ChartEntry(pasosHoy) { Label = "Hoy", ValueLabel = $"{pasosHoy} pasos", Color = SKColor.Parse("#FFCC00") }
            }
            };
            StepCountChartSemana.Chart = new DonutChart
            {
                Entries = new[]
                {
                new ChartEntry(pasosSemana) { Label = "Esta semana", ValueLabel = $"{pasosSemana} pasos", Color = SKColor.Parse("#FFCC00") }
            }
            };
            StepCountChartMes.Chart = new DonutChart
            {
                Entries = new[]
                {
                new ChartEntry(pasosMes) { Label = "Este mes", ValueLabel = $"{pasosMes} pasos", Color = SKColor.Parse("#FFCC00") }
            }
            };

            // Gráfico de distancia de pasos para día, semana, mes
            StepDistanceChartDia.Chart = new BarChart
            {
                Entries = new[]
                {
                new ChartEntry(distanciaHoy) { Label = "Hoy", ValueLabel = $"{distanciaHoy} KM", Color = SKColor.Parse("#FFCC00") }
            }
            };
            StepDistanceChartSemana.Chart = new BarChart
            {
                Entries = new[]
                {
                new ChartEntry(distanciaSemana) { Label = "Esta semana", ValueLabel = $"{distanciaSemana} KM", Color = SKColor.Parse("#FFCC00") }
            }
            };
            StepDistanceChartMes.Chart = new BarChart
            {
                Entries = new[]
                {
                new ChartEntry(distanciaMes) { Label = "Este mes", ValueLabel = $"{distanciaMes} KM", Color = SKColor.Parse("#FFCC00") }
            }
            };
        }

        // Métodos para obtener los pasos y la distancia de la base de datos
        private int ObtenerPasos(string periodo)
        {
            int pasos = 0;
            switch (periodo)
            {
                case "Diario":
                    pasos = SQlite.GetActividadPorFecha(SesionActual.UsuarioLogeado.Id, DateTime.Now).Pasos;
                    break;
                case "Semanal":
                    pasos = SQlite.GetHistorialActividad(SesionActual.UsuarioLogeado.Id)
                        .Where(x => x.Fecha >= DateTime.Now.AddDays(-7))
                        .Sum(x => x.Pasos);
                    break;
                case "Mensual":
                    pasos = SQlite.GetHistorialActividad(SesionActual.UsuarioLogeado.Id)
                        .Where(x => x.Fecha >= DateTime.Now.AddMonths(-1))
                        .Sum(x => x.Pasos);
                    break;
            }
            return pasos;
        }

        private float ObtenerDistancia(string periodo)
        {
            float distancia = 0;
            switch (periodo)
            {
                case "Diario":
                    distancia = SQlite.GetActividadPorFecha(SesionActual.UsuarioLogeado.Id, DateTime.Now).Distancia;
                    break;
                case "Semanal":
                    distancia = SQlite.GetHistorialActividad(SesionActual.UsuarioLogeado.Id)
                        .Where(x => x.Fecha >= DateTime.Now.AddDays(-7))
                        .Sum(x => x.Distancia);
                    break;
                case "Mensual":
                    distancia = SQlite.GetHistorialActividad(SesionActual.UsuarioLogeado.Id)
                        .Where(x => x.Fecha >= DateTime.Now.AddMonths(-1))
                        .Sum(x => x.Distancia);
                    break;
            }
            return distancia;
        }
    }
}