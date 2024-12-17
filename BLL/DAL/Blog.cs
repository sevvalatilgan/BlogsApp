using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace BLL.DAL;

public class Blog
{
    public int Id { get; set; }

    [Required]
    [StringLength(200)]
    public string Title { get; set; }

    [Required]
    public string Content { get; set; }

    public decimal? Rating { get; set; }

    [Required]
    public DateTime PublishDate { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }

    public List<BlogTag> BlogTags { get; set; } = new List<BlogTag>();
}