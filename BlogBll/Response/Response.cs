using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogBLL
{
    public class Response<T> : IResponse<T> where T : class
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string Error { get; set; }
        public T Data { get; set; }
        public Response() { Success = true; }
        public Response(T data, string message)
        {
            Success = true;
            Data = data;
            Message = message;
        }
        public Response(string error)
        {
            Success = false;
            Error = error;
        }

        public Response(T data)
        {
            Success = true;
            Data = data;
        }
    }
}
