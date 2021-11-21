using System.Collections.Generic;
using Xunit;

namespace MatchingApp.Tests
{
    public class MatchingLogicsTests
    {
        private readonly MatchingLogics _matchingLogics;
        public MatchingLogicsTests()
        {
            _matchingLogics = new MatchingLogics();
        }

        [Fact]
        public void Test_Example1_Should_Run_Ok()
        {
            // Arrange

            var input = new List<Order>
            {
                new Order{ Command = "sell", Price = 100.003, Amount = 2.4},
                new Order{ Command = "buy", Price = 90.394, Amount = 3.445}
            };

            var expectedResult = new MarketSection
            {
                Buy = new List<MarketValue>
                {
                    new MarketValue
                    {
                        Price = 90.394,
                        Volume = 3.445
                    }
                },
                Sell = new List<MarketValue>
                {
                    new MarketValue
                    {
                        Price = 100.003,
                        Volume = 2.4
                    }
                },
            };

            // Act and Assert
            AssertData(input, expectedResult);
        }

        [Fact]
        public void Test_Example2_Should_Run_Ok()
        {
            // Arrange

            var input = new List<Order>
            {
                new Order{ Command = "sell", Price = 100.003, Amount = 2.4},
                new Order{ Command = "buy", Price = 90.394, Amount = 3.445},
                new Order{ Command = "buy", Price = 89.394, Amount = 4.3},
                new Order{ Command = "sell", Price = 100.013, Amount = 2.2},
                new Order{ Command = "buy", Price = 90.15, Amount = 1.305},
                new Order{ Command = "buy", Price = 90.394, Amount = 1.0}
            };

            var expectedResult = new MarketSection
            {
                Buy = new List<MarketValue>
                {
                    new MarketValue
                    {
                        Price = 90.394,
                        Volume = 4.445
                    },
                    new MarketValue
                    {
                        Price = 90.15,
                        Volume = 1.305
                    },
                    new MarketValue
                    {
                        Price = 89.394,
                        Volume = 4.3
                    }
                },
                Sell = new List<MarketValue>
                {
                    new MarketValue
                    {
                        Price = 100.003,
                        Volume = 2.4
                    },
                    new MarketValue
                    {
                        Price = 100.013,
                        Volume = 2.2
                    }
                },
            };

            // Act and Assert
            AssertData(input, expectedResult);
        }

        [Fact]
        public void Test_Example3_Should_Run_Ok()
        {
            // Arrange

            var input = new List<Order>
            {
                new Order{ Command = "sell", Price = 100.003, Amount = 2.4},
                new Order{ Command = "buy", Price = 90.394, Amount = 3.445},
                new Order{ Command = "buy", Price = 89.394, Amount = 4.3},
                new Order{ Command = "sell", Price = 100.013, Amount = 2.2},
                new Order{ Command = "buy", Price = 90.15, Amount = 1.305},
                new Order{ Command = "buy", Price = 90.394, Amount = 1.0},
                new Order{ Command = "sell", Price = 90.394, Amount = 2.2}
            };

            var expectedResult = new MarketSection
            {
                Buy = new List<MarketValue>
                {
                    new MarketValue
                    {
                        Price = 90.394,
                        Volume = 2.245
                    },
                    new MarketValue
                    {
                        Price = 90.15,
                        Volume = 1.305
                    },
                    new MarketValue
                    {
                        Price = 89.394,
                        Volume = 4.3
                    }
                },
                Sell = new List<MarketValue>
                {
                    new MarketValue
                    {
                        Price = 100.003,
                        Volume = 2.4
                    },
                    new MarketValue
                    {
                        Price = 100.013,
                        Volume = 2.2
                    }
                },
            };

            // Act and Assert
            AssertData(input, expectedResult);
        }

        [Fact]
        public void Test_Example4_Trigger1st_Should_Run_Ok()
        {
            // Arrange

            var input = new List<Order>
            {
                new Order{ Command = "sell", Price = 100.003, Amount = 2.4},
                new Order{ Command = "buy", Price = 90.394, Amount = 3.445},
                new Order{ Command = "buy", Price = 89.394, Amount = 4.3},
                new Order{ Command = "sell", Price = 100.013, Amount = 2.2},
                new Order{ Command = "buy", Price = 90.15, Amount = 1.305},
                new Order{ Command = "buy", Price = 90.394, Amount = 1.0},
                new Order{ Command = "sell", Price = 90.394, Amount = 2.2},
                new Order{ Command = "sell", Price = 90.15, Amount = 3.4}
            };

            var expectedResult = new MarketSection
            {
                Buy = new List<MarketValue>
                {
                    new MarketValue
                    {
                        Price = 90.15,
                        Volume = 0.15
                    },
                    new MarketValue
                    {
                        Price = 89.394,
                        Volume = 4.3
                    }
                },
                Sell = new List<MarketValue>
                {
                    new MarketValue
                    {
                        Price = 100.003,
                        Volume = 2.4
                    },
                    new MarketValue
                    {
                        Price = 100.013,
                        Volume = 2.2
                    }
                },
            };

            // Act and Assert
            AssertData(input, expectedResult);
        }

        [Fact]
        public void Test_Example4_Trigger2nd_Should_Run_Ok()
        {
            // Arrange

            var input = new List<Order>
            {
                new Order{ Command = "sell", Price = 100.003, Amount = 2.4},
                new Order{ Command = "buy", Price = 90.394, Amount = 3.445},
                new Order{ Command = "buy", Price = 89.394, Amount = 4.3},
                new Order{ Command = "sell", Price = 100.013, Amount = 2.2},
                new Order{ Command = "buy", Price = 90.15, Amount = 1.305},
                new Order{ Command = "buy", Price = 90.394, Amount = 1.0},
                new Order{ Command = "sell", Price = 90.394, Amount = 2.2},
                new Order{ Command = "sell", Price = 90.15, Amount = 3.4},
                new Order{ Command = "buy", Price = 91.33, Amount = 1.8},
            };

            var expectedResult = new MarketSection
            {
                Buy = new List<MarketValue>
                {
                    new MarketValue
                    {
                        Price = 91.33,
                        Volume = 1.8
                    },
                    new MarketValue
                    {
                        Price = 90.15,
                        Volume = 0.15
                    },
                    new MarketValue
                    {
                        Price = 89.394,
                        Volume = 4.3
                    }
                },
                Sell = new List<MarketValue>
                {
                    new MarketValue
                    {
                        Price = 100.003,
                        Volume = 2.4
                    },
                    new MarketValue
                    {
                        Price = 100.013,
                        Volume = 2.2
                    }
                },
            };

            // Act and Assert
            AssertData(input, expectedResult);
        }

        [Fact]
        public void Test_Example4_Trigger3rd_Should_Run_Ok()
        {
            // Arrange

            var input = new List<Order>
            {
                new Order{ Command = "sell", Price = 100.003, Amount = 2.4},
                new Order{ Command = "buy", Price = 90.394, Amount = 3.445},
                new Order{ Command = "buy", Price = 89.394, Amount = 4.3},
                new Order{ Command = "sell", Price = 100.013, Amount = 2.2},
                new Order{ Command = "buy", Price = 90.15, Amount = 1.305},
                new Order{ Command = "buy", Price = 90.394, Amount = 1.0},
                new Order{ Command = "sell", Price = 90.394, Amount = 2.2},
                new Order{ Command = "sell", Price = 90.15, Amount = 3.4},
                new Order{ Command = "buy", Price = 91.33, Amount = 1.8},
                new Order{ Command = "buy", Price = 100.01, Amount = 4.0},
            };

            var expectedResult = new MarketSection
            {
                Buy = new List<MarketValue>
                {
                    new MarketValue
                    {
                        Price = 100.01,
                        Volume = 1.6
                    },
                    new MarketValue
                    {
                        Price = 91.33,
                        Volume = 1.8
                    },
                    new MarketValue
                    {
                        Price = 90.15,
                        Volume = 0.15
                    },
                    new MarketValue
                    {
                        Price = 89.394,
                        Volume = 4.3
                    }
                },
                Sell = new List<MarketValue>
                {
                    new MarketValue
                    {
                        Price = 100.013,
                        Volume = 2.2
                    }
                }
            };

            // Act and Assert
            AssertData(input, expectedResult);
        }

        [Fact]
        public void Test_Example4_Trigger4th_Should_Run_Ok()
        {
            // Arrange

            var input = new List<Order>
            {
                new Order{ Command = "sell", Price = 100.003, Amount = 2.4},
                new Order{ Command = "buy", Price = 90.394, Amount = 3.445},
                new Order{ Command = "buy", Price = 89.394, Amount = 4.3},
                new Order{ Command = "sell", Price = 100.013, Amount = 2.2},
                new Order{ Command = "buy", Price = 90.15, Amount = 1.305},
                new Order{ Command = "buy", Price = 90.394, Amount = 1.0},
                new Order{ Command = "sell", Price = 90.394, Amount = 2.2},
                new Order{ Command = "sell", Price = 90.15, Amount = 3.4},
                new Order{ Command = "buy", Price = 91.33, Amount = 1.8},
                new Order{ Command = "buy", Price = 100.01, Amount = 4.0},
                new Order{ Command = "sell", Price = 100.015, Amount = 3.8},
            };

            var expectedResult = new MarketSection
            {
                Buy = new List<MarketValue>
                {
                    new MarketValue
                    {
                        Price = 100.01,
                        Volume = 1.6
                    },
                    new MarketValue
                    {
                        Price = 91.33,
                        Volume = 1.8
                    },
                    new MarketValue
                    {
                        Price = 90.15,
                        Volume = 0.15
                    },
                    new MarketValue
                    {
                        Price = 89.394,
                        Volume = 4.3
                    }
                },
                Sell = new List<MarketValue>
                {
                    new MarketValue
                    {
                        Price = 100.013,
                        Volume = 2.2
                    },
                    new MarketValue
                    {
                        Price = 100.015,
                        Volume = 3.8
                    }
                },
            };

            // Act and Assert
            AssertData(input, expectedResult);
        }

        private void AssertData(List<Order> input, MarketSection expectedResult)
        {

            // Act
            var output = new List<Order>();
            foreach (var item in input)
            {
                output = _matchingLogics.MatchingData(output, item);
            }

            // Converting to Market Section data and grouping
            var actualResult = new MarketSection();
            actualResult = _matchingLogics.MarketSections(output);

            // Assert
            for (int i = 0; i < expectedResult.Buy.Count; i++)
            {
                Assert.Equal(expectedResult.Buy[i].Volume, actualResult.Buy[i].Volume);
                Assert.Equal(expectedResult.Buy[i].Price, actualResult.Buy[i].Price);
            }

            for (int i = 0; i < expectedResult.Sell.Count; i++)
            {
                Assert.Equal(expectedResult.Sell[i].Volume, actualResult.Sell[i].Volume);
                Assert.Equal(expectedResult.Sell[i].Price, actualResult.Sell[i].Price);
            }
        }
    }
}
