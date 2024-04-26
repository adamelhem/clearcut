#region (c) 2024 Adam Melhem All right reserved
//   Author     : Adam Melhem
//   Projet     : ClearCut
//   Created    : 26.4.2024
#endregion

namespace ClearCut
{
    public class TestLine
    {
        #region Public Constructors

        public TestLine()
        {
        }

        public TestLine(string x, string y, bool prediction)
        {
            X = x;
            Y = y;
            Prediction = prediction;
        }

        #endregion Public Constructors

        #region Public Properties

        public string Y { get; set; }
        public string X { get; set; }
        public bool Prediction { get; set; }

        #endregion Public Properties
    }
}
