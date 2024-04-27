using ClearCut.Model;
using Xunit;

namespace ClearcutUnitTestProject
{
    public class TestLinesUnitTest
    {
        [Fact]
        public void TestGetSumXY()
        {
            var expectedResult = 12;
            var testLines = new TestLines
            {
                new TestLine("1", "1", true),
                new TestLine("2", "2", false),
                new TestLine("3", "3", true)
            };
            var actualResult = testLines.GetSumXY();
            Assert.Equal(expectedResult, actualResult);
        }

        //TODO: add more unit tests
    }
}
