using System;
using Raylib_cs;
namespace CookingGame
{
    public class Spawner : InteractableGameObject
    {
        public Spawner(int x, int y, Texture2D texture, float imageScale, FoodObject spawnIngredient) : base(x, y, texture, imageScale)
        {
            heldFood = spawnIngredient;
        }


        public override void Interact(Player p)
        {
            // Ifall spelaren har en ingredient, släng iväg den
            if (p.IsHoldingIngredient())
            {
                p.heldFood = null;
            }
            // Annars ge spelaren en ny kopia av spawnIngredient
            else
            {
                p.heldFood = (FoodObject)heldFood.Clone();
            }
        }
    }
}