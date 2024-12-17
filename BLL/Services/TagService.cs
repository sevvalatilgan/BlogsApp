using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface ITagService 
    {
        public IQueryable<TagModel> Query();

        public ServiceBase Create(Tag record);

        public ServiceBase Update(Tag record);


        public ServiceBase Delete(int id);

    }

    public class TagService : ServiceBase,ITagService
    {
        public TagService(Db db) : base(db)
        {
        }

        public ServiceBase Create(Tag record)
        {
            if (_db.Tags.Any(t => t.Name.ToUpper() == record.Name.ToUpper().Trim()))
                return Error("Tags with the same name exists!");
            record.Name = record.Name?.Trim();
            _db.Tags.Add(record);   
            _db.SaveChanges();
            return Success("Tags created succesfully.");
        }

        public ServiceBase Delete(int id)
        {
            var entity = _db.Tags.Include(t => t.BlogTags).SingleOrDefault(t => t.Id == id);
            if (entity == null)
                return Error("Tags cannot be found!");
            if (entity.BlogTags.Any())
                return Error("Tags has relational blogs!");
            _db.Tags.Remove(entity);
            _db.SaveChanges();
            return Success("Tags deleted succesfully.");
        }

        public IQueryable<TagModel> Query()
        {
            return _db.Tags.OrderBy(t => t.Name).Select(t => new TagModel() { Record = t });
        }

        public ServiceBase Update(Tag record)
        {
            if (_db.Tags.Any(t => t.Id != record.Id && t.Name.ToUpper() == record.Name.ToUpper().Trim()))
                return Error("Tags with the same name exists!");

            var entity = _db.Tags.SingleOrDefault(t => t.Id == record.Id);
            if (entity == null)
                return Error("Tags cannot be found!.");
            entity.Name = record.Name?.Trim();
            _db.Tags.Update(entity);
            _db.SaveChanges();

            return Success("Tags updated succesfully.");
        }
    }
}
