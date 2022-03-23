using System;
using Raylib_cs;


namespace CookingGame
{
    public class Renderer
    {
        Rectangle table = new Rectangle(0, 340, 1920, 740);

        Plate plate = new Plate();



        public Renderer()
        {

        }

        public void Render()
        {
            DrawBackground();
        }

        public void DrawBackground()
        {

            Raylib.ClearBackground(Color.WHITE);

            Raylib.DrawRectangleRec(table, Color.BROWN);

        }

    }
}