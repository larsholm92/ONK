using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Model
{
    public class StockBundle
    {
        public int Id { get; set; }
        public List<Stock> Stocks { get; set; }
        public string Name { get; set; }
    }
}
