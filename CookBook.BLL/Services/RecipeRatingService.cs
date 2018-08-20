﻿using CookBook.BLL.Infrastructure;
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
    public class RecipeRatingService : IRecipeRatingService
    {
        readonly IUnitOfWork database;
        public RecipeRatingService(IUnitOfWork _database)
        {
            database = _database;
        }

        public void SetRating(int id, string email, int value)
        {
            if(value < 1 || value > 5)
                throw new ValidationException("Raiting should be 1-5", "");
            var recipe = database.Recipes.FirstOrDefault(r => r.Id == id);
            var user = database.Users.FirstOrDefault(u => u.Email == email);
            if (recipe == null || email == null)
                throw new ValidationException("Unknown data", "");
            RecipeRating recipeRating = new RecipeRating()
            {
                Id = database.RecipeRatings.Count() == 0 ? 1 : database.RecipeRatings.GetAll().OrderBy(o => o.Id).Last().Id + 1,
                Recipe = recipe,
                RecipeId = recipe.Id,
                Creator = user,
                CreatorId = user.Id,
                Rating = value
            };
            database.RecipeRatings.Create(recipeRating);
            database.Save();
            recipe.AvgRating = recipe.RecipesRatings.Select(s => s.Rating).ToList().Average();
            database.Save();
        }
    }
}
