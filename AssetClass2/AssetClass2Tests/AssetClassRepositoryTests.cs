using AssetClass2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetClass2Tests
{
    public class AssetClassRepositoryTests // testing class that ensures appropriate data is retrieved from the database
           {
        
        
            private readonly AssetClassRepository _repository;
            private readonly string _connectionString;

            public AssetClassRepositoryTests()
            {
                _connectionString = "Server=localhost;Database=assetclassanalyzer;uid=root;Pwd=password;";
                _repository = new AssetClassRepository(_connectionString);
            }

            [Theory] // data for each index that should be pulled when the user selects a either 1, 5, 10, 15 or 20 years
            [InlineData("uslargegrowth", 1, 0.8802, -0.3832, 0.2485)]
            [InlineData("uslargegrowth", 5, 0.3683, -0.0619, 0.1532)]
            [InlineData("uslargegrowth", 10, 0.2449, 0.0300, 0.1375)]
            [InlineData("uslargegrowth", 15, 0.2056, 0.0607, 0.1332)]
            [InlineData("uslargegrowth", 20, 0.1852, 0.0787, 0.1320)]
            [InlineData("ussmallvalue", 1, 0.7862, -0.3205, 0.2329)]
            [InlineData("ussmallvalue", 5, 0.3320, -0.0396, 0.1462)]
            [InlineData("ussmallvalue", 10, 0.2437, 0.0245, 0.1341)]
            [InlineData("ussmallvalue", 15, 0.2062, 0.0503, 0.1283)]
            [InlineData("ussmallvalue", 20, 0.1864, 0.0661, 0.1263)]
            [InlineData("ustotalbond", 1, 0.1818, -0.1325, 0.0247)]
            [InlineData("ustotalbond", 5, 0.1089, -0.0138, 0.0476)]
            [InlineData("ustotalbond", 10, 0.0850, 0.0152, 0.0501)]
            [InlineData("ustotalbond", 15, 0.0762, 0.0256, 0.0509)]
            [InlineData("ustotalbond", 20, 0.0713, 0.0311, 0.0512)]
        
            // below is the method used for testing the InlineData against what is actually pulled by the repository
        public void RollingAverage_ShouldReturnCorrectValues(string tableName, int years, double expectedHighest, double expectedLowest, double expectedAverage)
        {
                //Arrange & Act
                var result = _repository.RollingAverage(tableName, years);

                //Assert
                Assert.NotNull(result);
                Assert.Equal(3, result.Count());
                Assert.Equal(expectedLowest, result.ElementAt(1), 4);  
                Assert.Equal(expectedAverage, result.ElementAt(2), 4);
                Assert.Equal(expectedHighest, result.ElementAt(0), 4);
        }
        
    }
}

