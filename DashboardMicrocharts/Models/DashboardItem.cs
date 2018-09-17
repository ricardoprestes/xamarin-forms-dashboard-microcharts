using System.Collections.Generic;

namespace DashboardMicrocharts.Models
{
    public class DashboardItem
    {
        public string Name { get; set; }
        public EChartType Type { get; set; }
        public List<Serie> Series { get; set; }
    }

    public enum EChartType
    {
        BarChart,
        PointChart,
        LineChart,
        DonutChart,
        RadialGaugeChart,
        RadarChart
    }
}
