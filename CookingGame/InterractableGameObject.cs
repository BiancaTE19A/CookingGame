using System;
using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;

namespace CookingGame
{
    //Detta är alla saker som spelaren ska kunna klicka på, stove plate osv
    public class InteractableGameObject : GameObject
    {

        //Jag antar att alla interactable game objects har en held ingredient (egentligen borde det va i en till subclass)
        public FoodObject heldFood;

        public InteractableGameObject(int x, int y, Texture2D texture, float imageScale) : base(x, y, texture, imageScale)
        {
        }

        public override void Draw()
        {
            //Rita det vanliga
            base.Draw();
            //Sen rita ingrediensen ifall den finns
            if (IsHoldingIngredient())
            {
                heldFood.Draw();
            }
        }

        //Kallas när spelaren klickar på objectet med en referens till spelaren p
        public virtual void Interact(Player p)
        {
            Console.WriteLine("Base Interact");
        }

        //Förenklar att kolla ifall spelaren håller i en ingrediens
        public bool IsHoldingIngredient()
        {
            return heldFood != null;
        }
    }
}