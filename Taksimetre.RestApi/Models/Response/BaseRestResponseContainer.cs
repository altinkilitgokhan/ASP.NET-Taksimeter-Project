namespace Taksimeter.RestApi.Models.Response
{
    public class BaseRestResponseContainer<T>
    {
        public bool IsSucceed { get; set; }
        public T Response { get; set; }
        public string ErrorMessage { get; set; }
    }
}
