﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookBook.BLL.Interfaces
{
    public interface IUserRoleService
    {
        Task SetRoleAsync(string email, string role);
        Task PickUpRoleAsync(string email, string role);
        Task<IList<string>> GetUserRolesAsync(string email);
    }
}
