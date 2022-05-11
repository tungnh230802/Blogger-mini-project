namespace BlogBLL
{
    public interface IResponse<T> where T : class
    {
        string Error { get; set; }
        bool Success { get; set; }
        public T Data { get; set; }
    }
}