using System;

namespace TrueOrFalse.StatementNS.Model
{
    [Serializable]
    class Statement
    {
        public string Text { get; set; }
        public bool IsTrue { get; set; }

        public Statement()
        {

        }

        public Statement(string text, bool isTrue)
        {
            Text = text;
            IsTrue = isTrue;
        }
    }
}
