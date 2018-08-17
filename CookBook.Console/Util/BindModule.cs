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
        public override void Load()
        {
            Bind<IRoleService>().To<RoleService>();
            Bind<IUserService>().To<UserService>();
            Bind<IUserRoleService>().To<UserRoleService>();
            Bind<IRecipeService>().To<RecipeService>();
        }
    }
}
