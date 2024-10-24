using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microcharts;
using SkiaSharp;

namespace PETITEC.Vistas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class graficas_de_pasos : ContentPage
	{
        public graficas_de_pasos()
        {
            InitializeComponent();
            LoadCharts();
        }

        private void LoadCharts()
        {
            // Supongamos que los datos provienen de la base de datos o alguna API
            var actividadHoy = ObtenerActividadDiaria();
            var actividadSemana = ObtenerActividadSemanal();
            var actividadMes = ObtenerActividadMensual();

            var pasosHoy = ObtenerPasosHoy();
            var pasosSemana = ObtenerPasosSemana();
            var pasosMes = ObtenerPasosMes();

            var distanciaHoy = ObtenerDistanciaHoy();
            var distanciaSemana = ObtenerDistanciaSemana();
            var distanciaMes = ObtenerDistanciaMes();

            // Gráfico del conteo de pasos (día, semana, mes)
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

            // Gráfico de distancia de pasos (día, semana, mes)
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

        // Simulando funciones para obtener datos de actividad diaria, semanal y mensual
        private int ObtenerPasosHoy()
        {
            return 138; // Simula pasos de hoy
        }

        private int ObtenerPasosSemana()
        {
            return 5000; // Simula pasos de la semana
        }

        private int ObtenerPasosMes()
        {
            return 20000; // Simula pasos del mes
        }

        private float ObtenerDistanciaHoy()
        {
            return 0.10f; // Simula distancia de hoy
        }

        private float ObtenerDistanciaSemana()
        {
            return 3.5f; // Simula distancia de la semana
        }

        private float ObtenerDistanciaMes()
        {
            return 14.0f; // Simula distancia del mes
        }

        private (float KcalMovidas, float KcalRestantes) ObtenerActividadDiaria()
        {
            return (2f, 360f);  // Simulación de datos para calorías movidas y restantes
        }

        private (float KcalMovidas, float KcalRestantes) ObtenerActividadSemanal()
        {
            return (25f, 300f);  // Simulación de datos para la semana
        }

        private (float KcalMovidas, float KcalRestantes) ObtenerActividadMensual()
        {
            return (100f, 250f);  // Simulación de datos para el mes
        }
    }
}