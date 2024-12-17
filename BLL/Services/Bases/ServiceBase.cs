using BLL.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Bases
{
    public abstract class  ServiceBase
    {
        public bool IsSuccesfull { get; set; }

        public string Message { get; set; } = string.Empty;
        public bool IsSuccessful { get; set; }

        protected readonly Db _db;
        protected ServiceBase(Db db)
        {
            _db = db;
        }

        public ServiceBase Success(string message = "") 
        {
            IsSuccesfull = true;
            Message = message;
            return this;
        }
        public ServiceBase Error(string message = "")
        {
            IsSuccesfull = false;
            Message = message;
            return this;
        }
    }
}
