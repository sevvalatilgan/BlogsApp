using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace BLL.DAL;

public class Db : DbContext
{
    public DbSet<Blog> Blogs { get; set; }

    public DbSet<Tag> Tags { get; set; }

    public DbSet<BlogTag> BlogTags { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<Role> Roles { get; set; }

    public Db(DbContextOptions<Db> options): base(options)
    {
    }
}