using System;
using System.Numerics;
using Raylib_cs;

namespace CookingGame
{
    public class Lettuce : Ingredient
    {
        Texture2D image;
        public Rectangle rec;
        float imageScale = 0.3f;
        public bool active = false;


        public Lettuce(int tempx, int tempy, int width, int height, Texture2D tempImage)
        {
            rec = new Rectangle(tempx, tempy, width * imageScale, height * imageScale);
            image = tempImage;
        }

        public void Draw()
        {
            Raylib.DrawRectangleRec(rec, Color.BLUE);
            Raylib.DrawTextureEx(image, new Vector2(rec.x, rec.y), 0, imageScale, Color.WHITE);

        }

        public void Update()
        {
            if (active == false)
                return;


        }

        public void Move()
        {
            rec.x = Raylib.GetMouseX();
            rec.y = Raylib.GetMouseY();
        }
    }
}