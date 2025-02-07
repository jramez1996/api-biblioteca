using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPromocion.Application.Wrappers
{
    public class Response<T>
    {
        public Response(int v) { }

        public Response(T data, string message = null)
        {
            Success = true;
            Status = 200;
            Message = message;
            Data = data;
        }

        public Response(string message)
        {
            Success = false;
            Message = message;
        }

        public int Status { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }

        public List<string> Errors { get; set; }

        public T Data { get; set; }
    }
}
