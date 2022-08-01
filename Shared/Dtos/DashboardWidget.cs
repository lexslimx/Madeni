using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madeni.Shared.Dtos
{
    public class DashboardWidget
    {
        public DashboardWidget()
        {
            TimeSeries = new List<decimal>();
        }
        public string Title { get; set; } = string.Empty;
        public decimal Total { get; set; } = 0;
        public List<decimal> TimeSeries { get; set; }
        public decimal Balance { get; set; } = 0;
        public WidgetType WidgetType { get; set; }
        public int DisplayOrder { get; set; } = 0;
    }
}
