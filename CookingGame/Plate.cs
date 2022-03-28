using System;
using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;

namespace CookingGame
{
    public class Plate : InteractableGameObject
    {
        public Plate(int x, int y, Texture2D texture, float imageScale) : base(x, y, texture, imageScale)
        {

        }

        public override void Interact(Player p)
        {
            //Ifall spelaren håller i en ingrediens
            if (p.IsHoldingIngredient())
            {
                //Ifall det finns en ingrediens på tallriken, gör något konstig combine sak
                if (IsHoldingIngredient())
                {

                }
                //Annars ta spellarens ingrediens och lägg den på tallriken
                else
                {
                    heldIngredient = p.heldIngredient;
                    p.heldIngredient = null;
                    heldIngredient.MoveTo(rec.x, rec.y);
                }
            }
            //Annars plockar spelaren upp det som finns på tallriken
            else
            {
                p.heldIngredient = heldIngredient;
                heldIngredient = null;
                p.heldIngredient.MoveTo(p.mousePosition.X, p.mousePosition.Y);
            }
        }
    }
}