using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace new_blog.Models
{
    public class IndexViewModel
    {
        public FilterViewModel Filter { get; set; }
        public IEnumerable<Post> Posts { get; set; }
    }
}
