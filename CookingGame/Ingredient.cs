using System;
using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;

namespace CookingGame
{
    public class Ingredient : GameObject
    {
        public Ingredient(int x, int y, Texture2D texture, float imageScale) : base(x, y, texture, imageScale)
        {
        }

        //Moves ingredient to entered position
        public void MoveTo(float x, float y)
        {
            rec.x = x;
            rec.y = y;
        }
    }
}