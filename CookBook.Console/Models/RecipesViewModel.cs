﻿using CookBook.BLL.DTO;
using System;

namespace CookBook.Console.Models
{
    public class RecipesViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Content { get; set; }
        public double AverageRating { get; set; }
        public DateTime CreationDate { get; set; }
        public string ImageUrl { get; set; }
        public UserDTO Creator { get; set; }
    }
}
