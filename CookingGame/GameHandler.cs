using System;
using Raylib_cs;
using System.Collections.Generic;

namespace CookingGame
{
    public class GameHandler
    {
        int lettuceWidth = 1201;
        int lettuceHeight = 1050;

        Renderer renderer;

        List<Lettuce> lettuceList = new();
        Texture2D lettuceTexture;
        Lettuce activeLettuce;

        public GameHandler()
        {
            Raylib.InitWindow(1920, 1080, "Hello World");

            renderer = new Renderer();

            lettuceTexture = Raylib.LoadTexture(@"lettuce.png");

            lettuceList.Add(new Lettuce(40, 200, lettuceWidth, lettuceHeight, lettuceTexture));

            Run();
        }

        public async void Run()
        {
            while (!Raylib.WindowShouldClose())
            {
                //LOGIC

                for (int i = lettuceList.Count - 1; i >= 0; i--)
                {
                    lettuceList[i].Update();

                    if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT) && Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), lettuceList[i].rec) && !lettuceList[i].active)
                    {

                        Lettuce newLettuce = new Lettuce(Raylib.GetMouseX(), Raylib.GetMouseY(), lettuceWidth, lettuceHeight, lettuceTexture);
                        activeLettuce = newLettuce;
                        lettuceList.Add(newLettuce);
                        // while (Raylib.IsMouseButtonUp(MouseButton.MOUSE_BUTTON_LEFT))
                        // {
                        //     lettuceList[0].rec.x = Raylib.GetMouseX();
                        //     lettuceList[0].rec.y = Raylib.GetMouseY();
                        // }
                    }
                }
                if (activeLettuce != null)
                {
                    activeLettuce.Move();
                }


                //DRAW
                Raylib.BeginDrawing();

                renderer.Render();

                foreach (var lettuce in lettuceList)
                {
                    lettuce.Draw();
                }

                Raylib.EndDrawing();
            }
        }

    }
}