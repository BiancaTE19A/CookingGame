using System;
using System.Collections.Generic;
using Raylib_cs;

namespace CookingGame
{
    //Det är alla foodobjects som kan bli kombinerad av två olika ingredients
    public class Recipe : FoodObject
    {

        //De två ingredienserna som combinerar till receptet
        Ingredient Ingredient1;
        Ingredient Ingredient2;

        public Recipe(int x, int y, Texture2D texture, float imageScale, Ingredient Ingredient1, Ingredient Ingredient2) : base(x, y, texture, imageScale)
        {
            this.Ingredient1 = Ingredient1;
            this.Ingredient2 = Ingredient2;
        }

        //Förenklade checks
        public bool IsIngredientRequired(Ingredient i)
        {
            return i.GetType() == Ingredient1.GetType() || i.GetType() == Ingredient2.GetType();
        }

        public bool IngredientsMatch(Ingredient i1, Ingredient i2)
        {
            return i1.GetType() == Ingredient1.GetType() && i2.GetType() == Ingredient2.GetType() || i1.GetType() == Ingredient2.GetType() && i2.GetType() == Ingredient1.GetType();
        }
    }
}