using BLL.DAL;
using System.ComponentModel;
using BLL.Models;

namespace BLL.Models
{
    public class TagModel
    {
        public Tag Record { get; set; }

        public string Name => Record.Name;

        public string Blogs => string.Join(", ", Record.BlogTags?.Select(bt => bt.Blog?.Title));
        public List<int?> BlogIds
        {
            get => Record.BlogTags?.Select(bt => bt.BlogId).ToList();
            set => Record.BlogTags = value.Select(v => new BlogTag { BlogId = v }).ToList();
        }

    }
}
