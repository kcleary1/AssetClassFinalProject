using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetClass2
{
    public class AssetClassCalculator  // class used for processing database information appropriately based on user selctions
    {
        // below is the method which processes $1000 against each applicable rolling average - showing growth or loss of value
        public static (decimal Highest, decimal Lowest, decimal Average) CalculateInvestmentResults(IEnumerable<double> rollingAverages, int years)
        {
            if (rollingAverages == null || rollingAverages.Count() != 3)
            {
                throw new ArgumentException("Invalid rolling averages data");
            }

            decimal lowest = (decimal)(1000 * Math.Pow(1 + rollingAverages.ElementAt(1), years));
            decimal average = (decimal)(1000 * Math.Pow(1 + rollingAverages.ElementAt(2), years));
            decimal highest = (decimal)(1000 * Math.Pow(1 + rollingAverages.ElementAt(0), years));

            return (highest, lowest, average);
        }
    }
}
