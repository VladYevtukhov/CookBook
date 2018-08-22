﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using CookBook.BLL.Interfaces;
using CookBook.BLL.Services;

namespace CookBook.Console.Util
{
    public class BindModule : NinjectModule
    {
        /*private string connectionString;
        public BindModule(string _connectionString)
        {
            connectionString = _connectionString;
        }*/
        public override void Load()
        {
            Bind<IRoleService>().To<RoleService>();
            Bind<IUserService>().To<UserService>();
            Bind<IUserRoleService>().To<UserRoleService>();
            Bind<IRecipeService>().To<RecipeService>();
            Bind<ICategoryService>().To<CategoryService>();
            Bind<ICommentService>().To<CommentService>();
            Bind<ICookingMethodService>().To<CookingMethodService>();
            Bind<ICitchenCountryService>().To<CountryService>();
            Bind<IIngredientTypeService>().To<IngredientTypeService>();
            Bind<IProductService>().To<ProductService>();
            Bind<IRecipeProductsService>().To<RecipeProductsService>();
            Bind<IRecipeRatingService>().To<RecipeRatingService>();
        }
    }
}
