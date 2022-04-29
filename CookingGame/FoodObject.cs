using System;
using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;

namespace CookingGame
{
    //Detta är alla saker som ska flyttas runt av spelaren
    public class FoodObject : GameObject
    {
        public FoodObject(int x, int y, Texture2D texture, float imageScale) : base(x, y, texture, imageScale)
        {
        }

        //Flyttar ingredient till den positionen
        public void MoveTo(float x, float y)
        {
            rec.x = x;
            rec.y = y;
        }
    }
}