﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : EfEntityRepositoryBase<Brand, CarReCapDbContext>, IBrandDal
    {
        public void Add(Brand entity)
        {
            using (CarReCapDbContext context = new CarReCapDbContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Brand entity)
        {
            using (CarReCapDbContext context = new CarReCapDbContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();

            }
        }

            public Brand Get(Expression<Func<Brand, bool>> filter = null)

            {
                using (CarReCapDbContext context = new CarReCapDbContext())
                {

                    return context.Set<Brand>().SingleOrDefault(filter);
                }
            }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            using (CarReCapDbContext context = new CarReCapDbContext())
            {
                return filter == null
                    ? context.Set<Brand>().ToList()
                    : context.Set<Brand>().Where(filter).ToList();

            }
        }

        public void Update(Brand entity)
        {
            using (CarReCapDbContext context = new CarReCapDbContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();

            }
        }
    }
}
