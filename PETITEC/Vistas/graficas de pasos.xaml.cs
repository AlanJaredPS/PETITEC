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
		public graficas_de_pasos ()
		{
			InitializeComponent ();
			LoadCharts();
		}

		private void LoadCharts()
		{
			//Datos graficos del circulo

			ActivityCircleChart.Chart = new DonutChart
			{
				Entries = new[]
				{
					new ChartEntry(2)
					{
						Label = "Moverse",
						ValueLabel = "2",
						Color = SKColor.Parse("#FFA500")
					},
					new ChartEntry(360)
					{
						Label = "Restante",
						ValueLabel = "360",
						Color = SKColor.Parse("#E0E0E0")
					}
				}
			};

			StepCountChart.Chart = new DonutChart
			{
				Entries = new[] 
				{
                    new ChartEntry(10) { Color = SKColor.Parse("#FFCC00") },
                    new ChartEntry(20) { Color = SKColor.Parse("#FFCC00") },
                    new ChartEntry(30) { Color = SKColor.Parse("#FFCC00") },
                    new ChartEntry(40) { Color = SKColor.Parse("#FFCC00") },
                    new ChartEntry(50) { Color = SKColor.Parse("#FFCC00") }
                }
			};

			StepDistanceChart.Chart = new BarChart
			{
				Entries = new[]
				{
					new ChartEntry(1)
					{
						Color = SKColor.Parse("#FFCC00"),
						Label = "0.10 KM"
					}
				}
			};
		}
	}
}