﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.DAL.Entities
{
    public class RecipeProducts
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public int ProductId { get; set; }
    }
}
