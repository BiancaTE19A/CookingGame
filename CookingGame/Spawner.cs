using System;
using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;

namespace CookingGame
{
    public class Spawner : InteractableGameObject
    {
        public Spawner(int x, int y, Texture2D texture, float imageScale, Ingredient spawnIngredient) : base(x, y, texture, imageScale)
        {
            heldIngredient = spawnIngredient;
        }


        public override void Interact(Player p)
        {
            // Ifall spelaren har en ingredient, släng iväg den
            if (p.IsHoldingIngredient())
            {
                p.heldIngredient = null;
            }
            // Annars ge spelaren en ny kopia av spawnIngredient
            else
            {
                p.heldIngredient = (Ingredient)heldIngredient.Clone();
            }
        }
    }
}