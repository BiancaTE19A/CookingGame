using System;
using Raylib_cs;

namespace CookingGame
{
    public class Plate
    {
        Rectangle plate = new Rectangle(1460, 440, 25, 25);

        public Plate()
        {
            Draw();
        }

        public void Draw()
        {
            Raylib.DrawRectangleRec(plate, Color.WHITE);
        }
    }
}