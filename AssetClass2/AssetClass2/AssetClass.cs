using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetClass2
{
    public class AssetClass  //class that is used to provide a framework for the needed information for each investment index available for selection
    {
        public int Years { get; set; }
        public decimal Highest { get; set; }
        public decimal Lowest { get; set; }
        public decimal Average { get; set; }
    }
}
