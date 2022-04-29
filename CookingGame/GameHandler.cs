using System;
using Raylib_cs;
using System.Collections.Generic;
namespace CookingGame
{
    public class GameHandler
    {
        Renderer renderer;
        Player player;

        List<InteractableGameObject> interactables = new List<InteractableGameObject>();

        List<Recipe> recipeList = new List<Recipe>();

        //En dictionary med alla texturer för enklare tillgång
        Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();

        public GameHandler()
        {
            Raylib.InitWindow(1920, 1080, "Game");
            //Hämta nödvändig data
            renderer = new Renderer();
            player = new Player();
            textures.Add("Hamburger", Raylib.LoadTexture("Assets/hamburger.png"));
            textures.Add("HamburgerBread", Raylib.LoadTexture("Assets/hamburger_bread.png"));
            textures.Add("Hotdog", Raylib.LoadTexture("Assets/hotdog.png"));
            textures.Add("HotdogBread", Raylib.LoadTexture("Assets/hotdog_bread.png"));
            textures.Add("HotdogSausage", Raylib.LoadTexture("Assets/hotdog_sausage.png"));
            textures.Add("Lettuce", Raylib.LoadTexture("Assets/lettuce.png"));
            textures.Add("Stove", Raylib.LoadTexture("Assets/stove.png"));
            textures.Add("Plate", Raylib.LoadTexture("Assets/plate.png"));

            //Lägger till alla recipies i Recipe listan för att senare rita ut dem
            recipeList.Add(new Recipe(0, 0, textures["Hotdog"], 0.2f, new HotdogBread(0, 0, textures["HotdogBread"], 0.3f), new HotdogSausage(0, 0, textures["HotdogSausage"], 0.3f)));

            //Lägger till alla object som ska kunna dupliceras i Interactable listan för att senare rita ut dem
            interactables.Add(new Spawner(300, 500, textures["HotdogBread"], 0.4f, new HotdogBread(300, 500, textures["HotdogBread"], 0.4f)));
            interactables.Add(new Spawner(300, 800, textures["HotdogSausage"], 0.4f, new HotdogSausage(300, 800, textures["HotdogSausage"], 0.4f)));

            interactables.Add(new Plate(1100, 500, textures["Plate"], 0.2f, recipeList));

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
        //Privat function som samlar in alla olika gameobject i scenen (för att rita de t.ex.), eftersom de är utspridda överallt
        private List<GameObject> GetAllGameObjects()
        {
            List<GameObject> gameObjects = new List<GameObject>();
            gameObjects.AddRange(interactables);
            if (player.IsHoldingIngredient())
            {
                gameObjects.Add(player.heldFood);
            }
            return gameObjects;
        }
    }
}