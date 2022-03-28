using System;
using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;

namespace CookingGame
{
    public class GameHandler
    {
        Renderer renderer;

        Player player;

        List<InteractableGameObject> interactables = new List<InteractableGameObject>();

        //En dictionary med alla texturer för enklare tillgång
        Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();

        public GameHandler()
        {
            Raylib.InitWindow(1920, 1080, "Game");

            renderer = new Renderer();

            player = new Player();

            textures.Add("Hamburger", Raylib.LoadTexture("Assets/hamburger.png"));
            textures.Add("HamburgerBread", Raylib.LoadTexture("Assets/hamburger_bread.png"));
            textures.Add("Hotdog", Raylib.LoadTexture("Assets/hotdog.png"));
            textures.Add("HotdogBread", Raylib.LoadTexture("Assets/hotdog_bread.png"));
            textures.Add("HotdogSausage", Raylib.LoadTexture("Assets/hotdog_sausage.png"));
            textures.Add("Lettuce", Raylib.LoadTexture("Assets/lettuce.png"));

            interactables.Add(new Spawner(300, 500, textures["HamburgerBread"], 0.4f, new HamburgerBread(300, 500, textures["HamburgerBread"], 0.4f)));

            interactables.Add(new Plate(1400, 500, textures["Lettuce"], 0.3f));

            Run();
        }

        public void Run()
        {
            while (!Raylib.WindowShouldClose())
            {
                //LOGIC
                player.Update();
                //Kollar ifall spelaren klickar på någon av interactables och isåfall interagerar med de
                player.CheckClickOnInteractables(interactables);

                //DRAW
                Raylib.BeginDrawing();

                renderer.Render(GetAllGameObjects());

                Raylib.EndDrawing();
            }
        }

        //Privat function som samlar in alla olika gameobjects i scenen (för att rita de t.ex.), eftersom de är utspridda överallt
        private List<GameObject> GetAllGameObjects()
        {
            List<GameObject> gameObjects = new List<GameObject>();
            gameObjects.AddRange(interactables);
            if (player.IsHoldingIngredient())
            {
                gameObjects.Add(player.heldIngredient);
            }
            return gameObjects;
        }

    }
}