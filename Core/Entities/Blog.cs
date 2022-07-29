using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Blog:BaseModel
    {
        [Required(ErrorMessage = "Title Is Required")]
        [MaxLength(100, ErrorMessage = "Title Must Be Less Than 100 Character")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Body Is Required")]
        [MaxLength(1000, ErrorMessage = "Body Must Be Less Than 100 Character")]
        public string Body { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
