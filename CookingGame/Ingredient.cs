using System;
using System.Collections.Generic;
using Raylib_cs;

namespace CookingGame
{
    //Detta är alla FoodObjects som kan kombineras till en recipe
    public class Ingredient : FoodObject
    {
        public Ingredient(int x, int y, Texture2D texture, float imageScale) : base(x, y, texture, imageScale)
        {
        }
    }
}