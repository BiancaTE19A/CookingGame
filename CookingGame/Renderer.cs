using System;
using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;


namespace CookingGame
{
    public class Renderer
    {
        Rectangle table = new Rectangle(0, 340, 1920, 740);

        public void Render(List<GameObject> objects)
        {
            DrawBackground();

            foreach (var gameObject in objects)
            {
                gameObject.Draw();
            }
        }

        public void DrawBackground()
        {

            Raylib.ClearBackground(Color.WHITE);

            Raylib.DrawRectangleRec(table, Color.BROWN);
        }


    }
}