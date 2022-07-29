using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class BlogDTO
    {
        public long id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public string creationDate { get; set; }
    }
    public class BlogItem
    {
        public long id { get; set; }
        public string title { get; set; }
    }
}
