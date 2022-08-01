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
        }
        public string? UserId { get; set; }
        public List<DashboardWidget> DashboardWidgets { get; set; }
    }
}