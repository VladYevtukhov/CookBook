﻿using AutoMapper;
using CookBook.BLL.DTO;
using CookBook.BLL.Infrastructure;
using CookBook.BLL.Interfaces;
using CookBook.DAL.Entities;
using CookBook.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.BLL.Services
{
    public class CookingMethodService: ICookingMethodService
    {
        IUnitOfWork database;
        public CookingMethodService(IUnitOfWork _database)
        {
            database = _database;
        }

        public IEnumerable<CookingMethodDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CookingMethod, CookingMethodDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<CookingMethod>, List<CookingMethodDTO>>(database.CookingMethods.GetAll());
        }

        public void SetCookingMethod(string name)
        {
            var cook = database.CookingMethods.FirstOrDefault(c => c.Name == name);
            if (cook != null)
                throw new ValidationException("Category is already exist", "");
            cook = new CookingMethod()
            {
                Id = database.CookingMethods.Count() == 0 ? 1 : database.CookingMethods.GetAll().OrderBy(o => o.Id).Last().Id + 1,
                Name = name
            };
            database.CookingMethods.Create(cook);
            database.Save();
        }
    }
}
