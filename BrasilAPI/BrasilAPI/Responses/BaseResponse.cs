namespace SDKBrasilAPI.Responses
{ 
    public abstract class BaseResponse
    {
        internal string CalledURL { get; set; }
        internal string JsonResponse { get; set; }
    }
}
