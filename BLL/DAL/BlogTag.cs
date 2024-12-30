using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DAL;

public class BlogTag
{
    public int Id { get; set; }

    public int? BlogId { get; set; }
    public Blog Blog { get; set; }

    public int TagId { get; set; }
    public Tag Tag { get; set; }
}