using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class MainProduct
    {
        public int Pid { get; set; }
        public int Cid { get; set; }
        [Required(ErrorMessage ="Product Name Is Required")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Price Is Required")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Model Name Is Required")]
        public string Model { get; set; }
        [Required(ErrorMessage = "Color Is Required")]
        public string Color { get; set; }
    }
}
