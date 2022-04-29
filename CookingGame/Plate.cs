using System;
using System.Collections.Generic;
using Raylib_cs;

namespace CookingGame
{
    //Spelaren kan lägga ner och plocka upp ingredienser på tallriken och ifall den försöker lägga till två så kombineras dem 
    public class Plate : InteractableGameObject
    {
        List<Recipe> recipeList = new List<Recipe>();

        public Plate(int x, int y, Texture2D texture, float imageScale, List<Recipe> recipeList) : base(x, y, texture, imageScale)
        {
            this.recipeList = recipeList;
        }

        public override void Interact(Player p)
        {
            //Ifall spelaren håller i en ingrediens
            if (p.IsHoldingIngredient())
            {
                //Ifall det finns en ingrediens på tallriken, combine ingredients
                if (IsHoldingIngredient())
                {

                    //Kolla varje recipe
                    foreach (var recipe in recipeList)
                    {
                        //Ifall de matchar
                        if (recipe.IngredientsMatch((Ingredient)heldFood, (Ingredient)p.heldFood))
                        {
                            heldFood = (FoodObject)recipe.Clone();
                            p.heldFood = null;
                            heldFood.MoveTo(rec.x, rec.y);
                        }
                    }
                }
                //Annars ta spellarens ingrediens och lägg den på tallriken
                else
                {
                    heldFood = p.heldFood;
                    p.heldFood = null;
                    heldFood.MoveTo(rec.x, rec.y);
                }
            }
            //Annars plockar spelaren upp det som finns på tallriken
            else
            {

                if (IsHoldingIngredient())
                {
                    p.heldFood = heldFood;
                    heldFood = null;
                    p.heldFood.MoveTo(p.position.X, p.position.Y);
                }
            }
        }
    }
}