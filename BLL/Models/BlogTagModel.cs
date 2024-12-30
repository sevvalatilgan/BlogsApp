using BLL.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models;

namespace BLL.Models
{
    public class BlogTagModel
    {
        public BlogTag Record { get; set; }

        public BlogModel Blog => new BlogModel { Record = Record.Blog };
        
        public TagModel Tag => new TagModel { Record = Record.Tag };

        public string BlogTitle => Record.Blog?.Title;

        public string TagName => Record?.Tag?.Name;
      

    }
}
