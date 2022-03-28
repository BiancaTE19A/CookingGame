using System;
using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;

namespace CookingGame
{
    public class GameObject
    {
        //Hitbox
        public Rectangle rec;

        public Texture2D texture;
        public float imageScale;

        public GameObject(int x, int y, Texture2D texture, float imageScale)
        {
            this.texture = texture;
            this.imageScale = imageScale;

            rec = new Rectangle(x, y, texture.width * imageScale, texture.height * imageScale);
        }

        //Ritar texturen med rätt scale på hitboxens x och y
        public virtual void Draw()
        {
            Raylib.DrawTextureEx(texture, new Vector2(rec.x, rec.y), 0, imageScale, Color.WHITE);
        }

        //Snodd clone funktion
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}