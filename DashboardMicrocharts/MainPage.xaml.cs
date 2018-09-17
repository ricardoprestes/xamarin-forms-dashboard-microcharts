using DashboardMicrocharts.Models;
using Microcharts;
using Newtonsoft.Json;
using SkiaSharp;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Xamarin.Forms;

namespace DashboardMicrocharts
{
    public partial class MainPage : ContentPage
    {

        public List<DashboardItem> Dashboards { get; set; }

        public MainPage()
        {
            InitializeComponent();

            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(MainPage)).Assembly;
            Stream stream = assembly.GetManifestResourceStream("DashboardMicrocharts.dashboards.json");
            string json = "";
            using (var reader = new StreamReader(stream))
            {
                json = reader.ReadToEnd();
            }

            Dashboards = JsonConvert.DeserializeObject<List<DashboardItem>>(json);
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
                        chart = new BarChart { Entries = GetEntries(item) };
                        break;
                    case EChartType.PointChart:
                        chart = new PointChart { Entries = GetEntries(item) };
                        break;
                    case EChartType.LineChart:
                        chart = new LineChart { Entries = GetEntries(item) };
                        break;
                    case EChartType.DonutChart:
                        chart = new DonutChart { Entries = GetEntries(item) };
                        break;
                    case EChartType.RadialGaugeChart:
                        chart = new RadialGaugeChart { Entries = GetEntries(item) };
                        break;
                    case EChartType.RadarChart:
                        chart = new RadarChart { Entries = GetEntries(item) };
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

        List<Microcharts.Entry> GetEntries(DashboardItem dashboard)
        {
            var entries = new List<Microcharts.Entry>();
            foreach (var serie in dashboard.Series)
            {
                entries.Add(new Microcharts.Entry(serie.Value)
                {
                    Label = serie.Label,
                    ValueLabel = serie.ValueLabel,
                    Color = SKColor.Parse(serie.Color)
                });
            }
            return entries;
        }

    }
}
