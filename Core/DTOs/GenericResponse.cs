using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class GenericResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; }
    }
    public class GenericResponse<T>: GenericResponse where T : class
    {
        public T Response { get; set; }
    }
}
