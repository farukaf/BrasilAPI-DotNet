using System;
using System.Collections.Generic;
using System.Text;

namespace BrasilAPI
{
    public class BrasilAPIException : Exception
    {
        public object ContentData { get; internal set; }

        public int Code { get; internal set; }
        public string URL { get; internal set; }
    }
}
