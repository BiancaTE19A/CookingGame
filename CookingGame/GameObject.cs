using System;
using Raylib_cs;
using System.Numerics;

namespace CookingGame
{
    //GameObject är allting som ska ha en textur, ska ritas, och kan förflyttas. Basically allting förutom backgrunden och spelaren
    public class GameObject
    {
        //Collisionbox
        public Rectangle rec;
        public Texture2D texture;
        public float imageScale;

        public GameObject(int x, int y, Texture2D texture, float imageScale)
        {
            this.texture = texture;
            this.imageScale = imageScale;
            rec = new Rectangle(x, y, texture.width * imageScale, texture.height * imageScale);
        }

        //Ritar texturen med rätt scale på collisionboxens x och y
        public virtual void Draw()
        {
            Raylib.DrawTextureEx(texture, new Vector2(rec.x, rec.y), 0, imageScale, Color.WHITE);
        }
        
        //Nån clone function som Albin hittade online
        //Används i Spawner klassen då spawnern skapar en kopia av objektet så att man kan göra ändringar på kopian utan att ändra bas-objektet
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}