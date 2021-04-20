using System;
using System.Collections.Generic;
using System.Text;

namespace SDKBrasilAPI
{
    public abstract class BaseResponse
    {
        internal string CalledURL { get; set; }
        internal string JsonResponse { get; set; }
    }
}
