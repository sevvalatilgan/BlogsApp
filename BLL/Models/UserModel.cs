using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BLL.DAL;
using System.ComponentModel;

namespace BLL.Models
{
    public class UserModel
    {
        public User Record { get; set; }

        [DisplayName ("User Name")]
        public string UserName => Record.UserName;

        public string Password => Record.Password;
        public string IsActive => Record.IsActive ? "Active" : "Not Active";

        public string Role => Record.Role?.Name;

        public string Blogs => string.Join(", ", Record.Blogs?.Select(b => b.Title));

        public ICollection<BlogModel>Blog {  get; set; } = new List<BlogModel>();

       
    }
}