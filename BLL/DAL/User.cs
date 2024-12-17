using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace BLL.DAL;

public class User
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string UserName { get; set; }

    [Required]
    [StringLength(100)]
    public string Password { get; set; }

    public bool IsActive { get; set; }

    public int RoleId { get; set; }
    public Role Role { get; set; }

    public List<Blog> Blogs { get; set; } = new List<Blog>();
}