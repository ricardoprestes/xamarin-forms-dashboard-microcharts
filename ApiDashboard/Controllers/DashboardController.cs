using ApiDashboard.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace ApiDashboard.Controllers
{
    public class DashboardController : ApiController
    {
        // GET: Dashboard
        public IEnumerable<DashboardItem> Get()
        {
            var series = new List<Serie> {
                new Serie { Label = "Janeiro", Value = 200, ValueLabel = "200", Color = "#266489" },
                new Serie { Label = "Fevereiro", Value = 400, ValueLabel = "400", Color = "#68B9C0" },
                new Serie { Label = "Março", Value = -100, ValueLabel = "-100", Color = "#90D585" }
            };

            var dashboards = new List<DashboardItem>
            {
                new DashboardItem{Name ="BarChart", Type=EChartType.BarChart, Series=series},
                new DashboardItem{Name ="PointChart", Type=EChartType.PointChart, Series=series},
                new DashboardItem{Name ="LineChart", Type=EChartType.LineChart, Series=series},
                new DashboardItem{Name ="DonutChart", Type=EChartType.DonutChart, Series=series},
                new DashboardItem{Name ="RadialGaugeChart", Type=EChartType.RadialGaugeChart, Series=series},
                new DashboardItem{Name ="RadarChart", Type=EChartType.RadarChart, Series=series},
            };

            return dashboards;
        }
    }
}