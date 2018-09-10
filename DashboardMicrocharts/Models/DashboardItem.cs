using Microcharts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DashboardMicrocharts.Models
{
    public class DashboardItem
    {
        public string Name { get; set; }
        public EChartType Type { get; set; }
        public List<Entry> Entries { get; set; }
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
