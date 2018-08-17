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
    public class UserService : IUserService
    {
        readonly IUnitOfWork database;
        public UserService(IUnitOfWork _database)
        {
            database = _database;
        }

        public void ConfirmEmail(string email)
        {
            var user = GetCurrentUser(email);
            user.EmailConfirmed = true;
            database.Users.Update(user);
            database.Save();
        }

        public void ChangeAboutUser(string email, string about)
        {
            var user = GetCurrentUser(email);
            user.About = about;
            database.Users.Update(user);
            database.Save();
        }

        public void CreateUser(RegisterUserDTO registerUserDTO)
        {
            if (registerUserDTO.Password.Length < 6)
                throw new ValidationException("min password length = 6", "");
            var user = database.Users.FirstOrDefault(u => u.Email == registerUserDTO.Email);
            if (user != null)
                throw new ValidationException("User is already exist", "");
            User newbie = new User()
            {
                Id = database.Users.GetAll().Count() == 0 ? 1 : database.Users.GetAll().OrderBy(o => o.Id).Last().Id + 1,
                Email = registerUserDTO.Email,
                ImageUrl = "http://missingkids-stage.adobecqms.net/etc/clientlibs/ncmec/poster/images/poster/en_US/noPhotoAvailable.jpg",
                Password = registerUserDTO.Password.GetHashCode().ToString(),
                UserName = registerUserDTO.Email,
                AvgRating = 0,
                About = ""
            };
            database.Users.Create(newbie);
            database.Save();
        }

        public void DeleteUser(string email)
        {
            var user = GetCurrentUser(email);
            user.IsDeleted = true;
            database.Users.Update(user);
            database.Save();
        }

        public void RestoreUser(string email)
        {
            var user = database.Users.FirstOrDefault(u => u.Email == email);
            if (user == null)
                throw new ValidationException("User not found", "");
            user.IsDeleted = false;
            database.Users.Update(user);
            database.Save();
        }

        public UserDTO GetUser(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            return mapper.Map<User, UserDTO>(database.Users.FirstOrDefault(u => u.Id == id));
        }

        public UserDTO GetUser(string email)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            return mapper.Map<User, UserDTO>(database.Users.FirstOrDefault(u => u.Email == email));
        }

        public IEnumerable<UserDTO> GetUsers()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<User>, List<UserDTO>>(database.Users.GetAll());
        }

        private User GetCurrentUser(string email)
        {
            var user = database.Users.FirstOrDefault(u => u.Email == email);
            if (user == null)
                throw new ValidationException("User not found", "");
            if(user.IsDeleted)
                throw new ValidationException("User is deleted", "");
            return user;
        }
    }
}
