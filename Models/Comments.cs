using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace practiceApi.Models
{
    public class Comments
    {
        public int id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public int? StockId { get; set; }
        public Stock? Stocks { get; set; }

    }
}