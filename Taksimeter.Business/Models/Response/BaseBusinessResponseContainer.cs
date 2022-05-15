namespace Taksimeter.Business.Models.Response
{
    public class BaseBusinessResponseContainer<T>
    {
        public bool IsSucceed { get; set; }
        public T Response { get; set; }
        public string ErrorMessage { get; set; }
    }
}
