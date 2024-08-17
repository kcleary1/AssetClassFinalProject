using Xunit;
using System;
using System.Collections.Generic;
using AssetClass2;

namespace AssetClass2Tests
{
    public class AssetClassCalculatorTests //class used to test processing of information that is taken from database
    {
        [Theory] // given return rate for 1, 5, 10, 15, and 20 years periods for each index, the expected ending value of $1000 is given
        [InlineData(new double[] { 0.8802, -0.3832, 0.2485}, 1, 1880.20, 616.80, 1248.50)]//Large Growth 1yr
        [InlineData(new double[] {0.3683, -0.0619, 0.1532}, 5, 4796.30, 726.52, 2039.50)]//Large Growth 5yr
        [InlineData(new double[] { 0.2449, 0.0300, 0.1375}, 10, 8940.15, 1343.92, 3626.72)]//Large Growth 10yr
        [InlineData(new double[] { 0.2056, 0.0607, 0.1332}, 15, 16521.47, 2420.41, 6525.27)]//Large Growth 15yr
        [InlineData(new double[] { 0.1852, 0.0787, 0.1320}, 20, 29911.13, 4550.02, 11937.92)]//Large Growth 20yr
        [InlineData(new double[] { 0.7862, -0.3205, 0.2329}, 1, 1786.20, 679.50, 1232.90)]//Small Value 1yr
        [InlineData(new double[] { 0.3320, -0.0396, 0.1462}, 5, 4192.96, 817.07, 1978.34)]//Small Value 5yr
        [InlineData(new double[] { 0.2437, 0.0245, 0.1341}, 10, 8854.34, 1273.85, 3519.76)]//Small Value 10yr
        [InlineData(new double[] { 0.2062, 0.0503, 0.1283}, 15, 16645.23, 2087.86, 6114.61)]//Small Value 15yr
        [InlineData(new double[] { 0.1864, 0.0661, 0.1263}, 20, 30522.69, 3597.15, 10791.50)]//Small Value 20yr
        [InlineData(new double[] { 0.1818, -0.1325, 0.0247}, 1, 1181.80, 867.50, 1024.70)]//Total Bond 1yr
        [InlineData(new double[] { 0.1089, -0.0138, 0.0476}, 5, 1676.73, 932.88, 1261.76)]//Total Bond 5yr
        [InlineData(new double[] {0.0850, 0.0152, 0.0501}, 10, 2260.98, 1162.83, 1630.45)]//Total Bond 10yr
        [InlineData(new double[] { 0.0762, 0.0256, 0.0509}, 15, 3008.81, 1461.07, 2105.82)]//Total Bond 15yr
        [InlineData(new double[] {0.0713, 0.0311, 0.0512}, 20, 3964.81, 1845.08, 2714.61)]//Total Bond 20yr
        
        // below is method used to test calculations of InlineData
        public void CalculateInvestmentResults_ShouldReturnCorrectValues(double[] rollingAverages, int years, decimal expectedHighest, decimal expectedLowest, decimal expectedAverage)
        {
            //Arrange
            var rollingAveragesList = new List<double>(rollingAverages);

            //Act
            var result = AssetClassCalculator.CalculateInvestmentResults(rollingAveragesList, years);

            //Assert
            Assert.Equal(expectedHighest, Math.Round(result.Highest, 2));
            Assert.Equal(expectedLowest, Math.Round(result.Lowest, 2));
            Assert.Equal(expectedAverage, Math.Round(result.Average, 2));
        }
    }
}