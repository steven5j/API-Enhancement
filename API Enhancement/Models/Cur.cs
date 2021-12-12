using System;
using System.Collections.Generic;

namespace API_Enhancement.Models
{
    public partial class Cur
    {
        public int Pk { get; set; }
        public string? BillPayerAccountId { get; set; }
        public string? LineItemUnblendedCost { get; set; }
        public string? LineItemUnblendedRate { get; set; }
        public string? LineItemUsageAccountId { get; set; }
        public string? LineItemUsageAmount { get; set; }
        public string? LineItemUsageStartDate { get; set; }
        public string? LineItemUsageEndDate { get; set; }
        public string? ProductProductName { get; set; }
    }
}
