using System;
using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;
namespace CookingGame
{
    public class HamburgerMeat : Ingredient
    {
        public HamburgerMeat(int x, int y, Texture2D texture, float imageScale) : base(x, y, texture, imageScale)
        {
        }
    }
}