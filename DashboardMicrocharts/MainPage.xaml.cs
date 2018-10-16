using DashboardMicrocharts.Models;
using Microcharts;
using Newtonsoft.Json;
using SkiaSharp;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DashboardMicrocharts
{
    public partial class MainPage : ContentPage
    {

        public List<DashboardItem> Dashboards { get; set; }

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            GetCharts();
        }

        async Task GetCharts()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://172.20.5.160:81/api/dashboard");
            var json = response.Content.ReadAsStringAsync().Result;
            if (string.IsNullOrWhiteSpace(json))
                return;
            Dashboards = JsonConvert.DeserializeObject<List<DashboardItem>>(json);
            ShowCharts();
        }

        void ShowCharts()
        {
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
