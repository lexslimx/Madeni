using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madeni.Shared.Dtos
{
    public class DashboardDto
    {
        public DashboardDto()
        {
            DashboardWidgets = new();
            UserId = string.Empty;
            ChartData = new List<DashboardWidget>();
        }
        public string? UserId { get; set; }
        public List<DashboardWidget> DashboardWidgets { get; set; }
        public List<DashboardWidget> ChartData { get; set; }
    }
}