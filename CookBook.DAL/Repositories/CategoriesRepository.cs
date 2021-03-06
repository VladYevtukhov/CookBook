﻿using CookBook.DAL.Interfaces;
using CookBook.Domain.EF;
using CookBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CookBook.DAL.Repositories
{
    public class CategoriesRepository : IRepository<Category>
    {
        readonly ApplicationDbContext mobileContext;
        public CategoriesRepository(ApplicationDbContext _mc)
        {
            mobileContext = _mc;
        }
        public int Count()
        {
            return mobileContext.Categories.Count();
        }

        public void Create(Category item)
        {
            var category = mobileContext.Categories.FirstOrDefault(p => p.Name == item.Name);
            if (category == null)
                mobileContext.Categories.Add(item);
        }

        public IEnumerable<Category> Find(Func<Category, bool> predicate)
        {
            return mobileContext.Categories.Where(predicate).ToList();
        }

        public IEnumerable<Category> Take(Func<Category, bool> predicate, int skipCount, int takeCount)
        {
            return mobileContext.Categories.Where(predicate).OrderBy(s => s.Id).Skip(skipCount).Take(takeCount);
        }

        public Category FirstOrDefault(Func<Category, bool> predicate)
        {
            return mobileContext.Categories.FirstOrDefault(predicate);
        }

        public Category Get(int id)
        {
            return mobileContext.Categories.First(p => p.Id == id);
        }

        public IEnumerable<Category> GetAll()
        {
            return mobileContext.Categories;
        }

        public void Remove(int id)
        {
            var category = mobileContext.Categories.FirstOrDefault(p => p.Id == id);
            if (category != null)
                mobileContext.Categories.Remove(category);
        }

        public void Remove(Category item)
        {
            var category = mobileContext.Categories.FirstOrDefault(p => p == item);
            if (category != null)
                mobileContext.Categories.Remove(category);
        }

        public void Update(Category item)
        {
            var category = mobileContext.Categories.FirstOrDefault(p => p.Id == item.Id);
            if (category != null)
            {
                category.Name = item.Name;
            }
        }
    }
}
