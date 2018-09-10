using DashboardMicrocharts.Models;
using Microcharts;
using SkiaSharp;
using System.Collections.Generic;
using Xamarin.Forms;

namespace DashboardMicrocharts
{
    public partial class MainPage : ContentPage
    {

        public List<DashboardItem> Dashboards { get; set; }

        public MainPage()
        {
            InitializeComponent();

            var entries = new List<Microcharts.Entry> {
                new Microcharts.Entry(200)
                {
                    Label = "Janeiro",
                    ValueLabel = "200",
                    Color = SKColor.Parse("#266489")
                },
                new Microcharts.Entry(400)
                {
                    Label = "Fevereiro",
                    ValueLabel = "400",
                    Color = SKColor.Parse("#68B9C0")
                },
                new Microcharts.Entry(-100)
                {
                    Label = "Março",
                    ValueLabel = "-100",
                    Color = SKColor.Parse("#90D585")
                }
            };

            Dashboards = new List<DashboardItem>
            {
                new DashboardItem { Name = "BarChart", Type = EChartType.BarChart, Entries = entries},
                new DashboardItem { Name = "PointChart", Type = EChartType.PointChart, Entries = entries},
                new DashboardItem { Name = "LineChart", Type = EChartType.LineChart, Entries = entries},
                new DashboardItem { Name = "DonutChart", Type = EChartType.DonutChart, Entries = entries},
                new DashboardItem { Name = "RadialGaugeChart", Type = EChartType.RadialGaugeChart, Entries = entries},
                new DashboardItem { Name = "RadarChart", Type = EChartType.RadarChart, Entries = entries}
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Chart chart = null;

            foreach (var item in Dashboards)
            {
                switch (item.Type)
                {
                    case EChartType.BarChart:
                        chart = new BarChart { Entries = item.Entries };
                        break;
                    case EChartType.PointChart:
                        chart = new PointChart { Entries = item.Entries };
                        break;
                    case EChartType.LineChart:
                        chart = new LineChart { Entries = item.Entries };
                        break;
                    case EChartType.DonutChart:
                        chart = new DonutChart { Entries = item.Entries };
                        break;
                    case EChartType.RadialGaugeChart:
                        chart = new RadialGaugeChart { Entries = item.Entries };
                        break;
                    case EChartType.RadarChart:
                        chart = new RadarChart { Entries = item.Entries };
                        break;
                    default:
                        break;
                }

                if (chart == null)
                    continue;

                var chartView = new Microcharts.Forms.ChartView { HeightRequest = 140, BackgroundColor = Color.White };
                chartView.Chart = chart;
                slCharts.Children.Add(chartView);
            }

        }

    }
}
