using System;
using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;

namespace CookingGame
{
    public class Stove : InteractableGameObject
    {
        public Stove(int x, int y, Texture2D texture, float imageScale) : base(x, y, texture, imageScale)
        {
        }
    }
}