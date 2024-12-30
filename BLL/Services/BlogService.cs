using BLL.Services.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BLL.DAL;
using BLL.Models;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public class BlogService : ServiceBase, IService<Blog, BlogModel>
    {
        public BlogService(Db db) : base(db) { }

        public IQueryable<BlogModel> Query()
        {
            return _db.Blogs.Include(b => b.BlogTags).ThenInclude(bt => bt.Tag).OrderBy(b => b.Title).Select(b => new BlogModel() { Record = b });
        }

        public ServiceBase Create(Blog record)
        {
            if (_db.Blogs.Any(b => b.Title.ToLower() == record.Title.ToLower().Trim()))
                return Error("Blog with the same title exists!");

            record.Title = record.Title?.Trim();
            _db.Blogs.Add(record);
            _db.SaveChanges();
            return Success("Blog created successfully.");
        }

        public ServiceBase Update(Blog record)
        {
            if (_db.Blogs.Any(b => b.Id != record.Id && b.Title.ToLower() == record.Title.ToLower().Trim()))
                return Error("Blog with the same title exists!");

            var entity = _db.Blogs.Include(b => b.BlogTags).SingleOrDefault(b => b.Id == record.Id);
            if (entity is null)
                return Error("Blog can't be found!");

            entity.Title = record.Title?.Trim();
            entity.Content = record.Content;
            entity.BlogTags = record.BlogTags;

            _db.Blogs.Update(entity);
            _db.SaveChanges();
            return Success("Blog updated successfully.");
        }

        public ServiceBase Delete(int id)
        {
            var entity = _db.Blogs.Include(b => b.BlogTags).SingleOrDefault(b => b.Id == id);
            if (entity is null)
                return Error("Blog can't be found!");

            _db.BlogTags.RemoveRange(entity.BlogTags);
            _db.Blogs.Remove(entity);
            _db.SaveChanges();
            return Success("Blog deleted successfully.");
        }
    }
}