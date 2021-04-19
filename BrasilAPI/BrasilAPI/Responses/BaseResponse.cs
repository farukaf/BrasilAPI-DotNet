using System;
using System.Collections.Generic;
using System.Text;

namespace BrasilAPI
{
    public abstract class BaseResponse
    {
        internal string CalledURL { get; set; }
        internal string JsonResponse { get; set; }
    }
}
