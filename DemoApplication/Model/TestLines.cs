#region (c) 2024 Adam Melhem All right reserved
//   Author     : Adam Melhem
//   Projet     : ClearCut
//   Created    : 26.4.2024
#endregion

using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ClearCut.Model
{
    internal class TestLines : ICollection<TestLine>
    {
        private readonly List<TestLine> _testLines;

        public TestLines() : this(new List<TestLine>())
        {
        }

        public TestLines(List<TestLine> testLines)
        {
            _testLines = testLines;
        }

        public int Count => _testLines.Count();

        public bool IsReadOnly => false;

        public void Add(TestLine item) =>
            _testLines.Add(item);

        public void Clear() =>
            _testLines.Clear();
        
        public bool Contains(TestLine item)
            => _testLines.Contains(item);

        public void CopyTo(TestLine[] array, int arrayIndex)
            => _testLines.CopyTo(array, arrayIndex);

        public IEnumerator<TestLine> GetEnumerator()
            => _testLines.GetEnumerator();

        public bool Remove(TestLine item)
            => _testLines.Remove(item);

        internal object GetAverageXY()
        {
            var xList = _testLines.AsParallel().Select(e => float.Parse(e.X)).ToList();
            var yList = _testLines.AsParallel().Select(e => float.Parse(e.Y)).ToList();
            var xSum = xList.Sum();
            var ySum = yList.Sum();
            var xCount = xList.Count();
            var yCount = yList.Count();
            return ((xSum + ySum) / (xCount + yCount));
        }

        internal float GetMaxXY()
        {
            var xList = _testLines.AsParallel().Select(e => float.Parse(e.X)).ToList();
            var yList = _testLines.AsParallel().Select(e => float.Parse(e.Y)).ToList();
            var xMax = xList.Max();
            var yMax = yList.Max();
            var maxXY = ((xMax > yMax) ? xMax : yMax);
            return maxXY;
        }

        internal float GetMinXY()
        {
            var xList = _testLines.AsParallel().Select(e => float.Parse(e.X)).ToList();
            var yList = _testLines.AsParallel().Select(e => float.Parse(e.Y)).ToList();
            var xMin = xList.Min();
            var yMin = yList.Min();
            return ((xMin > yMin) ? xMin : yMin);
        }

        internal float GetSumXY()
        {
            var xList = _testLines.AsParallel().Select(e => float.Parse(e.X)).ToList();
            var yList = _testLines.AsParallel().Select(e => float.Parse(e.Y)).ToList();
            var xSum = xList.Sum();
            var ySum = yList.Sum();
            return (xSum + ySum);
        }

        IEnumerator IEnumerable.GetEnumerator()
           => _testLines.GetEnumerator(); 
    }
}
