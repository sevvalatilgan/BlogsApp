using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL.Services
{


    public class BlogTagService : ServiceBase, IService<BlogTag, BlogTagModel>
    {
        public BlogTagService(Db db) : base(db)
        {
        }

        public IQueryable<BlogTagModel> Query()
        {
            return _db.BlogTags.OrderBy(bt => bt.BlogId).Select(bt => new BlogTagModel() { Record = bt });
        }

        public ServiceBase Create(BlogTag record)
        {
            if (_db.BlogTags.Any(bt => bt.BlogId == record.BlogId && bt.TagId == record.TagId))
                return Error("This BlogTag association already exists!");

            _db.BlogTags.Add(record);
            _db.SaveChanges();
            return Success("BlogTag created successfully.");
        }

        public ServiceBase Delete(int id)
        {
            var entity = _db.BlogTags.Find(id);
            if (entity is null)
                return Error("BlogTag can't be found!");
            _db.BlogTags.Remove(entity);
            _db.SaveChanges();
            return Success("BlogTag deleted successfully.");
        }

       
        public ServiceBase Update(BlogTag record)
        {
            var entity = _db.BlogTags.SingleOrDefault(bt => bt.Id == record.Id);
            if (entity is null)
                return Error("BlogTag can't be found!");

            entity.BlogId = record.BlogId;
            entity.TagId = record.TagId;

            _db.BlogTags.Update(entity);
            _db.SaveChanges();
            return Success("BlogTag updated successfully.");
        }
    }

}
