﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.DAL.Entities
{
    public class RecipeRating
    {
        public int Id { get; set; }
        public int CreatorId { get; set; }
        public Users Creator { get; set; }
        public int RecipeId { get; set; }
        public Recipes Recipe { get; set; }
        public int Rating { get; set; }
    }
}
