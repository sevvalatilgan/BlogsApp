using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BLL.DAL;

namespace BLL.Models
{
    public class BlogModel
    {
        public Blog Record { get; set; }

        public string Title => Record.Title;

        public string Content => Record.Content;

        public string Rating => Record.Rating.HasValue ? Record.Rating.Value.ToString("N2") : "No Rating";

        public string PublishDate => Record.PublishDate.ToString("MM/dd/yyyy");

        public string Tags => string.Join(", ", Record.BlogTags?.Select(bt => bt.Tag?.Name));

        public List<int> TagIds
        {
            get => Record.BlogTags?.Select(bt => bt.TagId).ToList();
            set => Record.BlogTags = value.Select(v => new BlogTag { TagId = v }).ToList();
        }

        public UserModel User { get; set; } 
    }
}