using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.ShaligramModel
{
    public class ItemCore
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int Qty { get; set; }
        public int Price { get; set; }
        public int Total { get; set; }
    }
}
