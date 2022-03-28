using System;
using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;

namespace CookingGame
{
    public class Player
    {
        public Vector2 mousePosition;

        public Ingredient heldIngredient = null;

        public void Update()
        {
            //Updatera spelarens (musens) position
            mousePosition = Raylib.GetMousePosition();

            //Flytta ingrediensen som spelaren håller i till musen
            if (IsHoldingIngredient())
            {
                heldIngredient.MoveTo(mousePosition.X, mousePosition.Y);
            }
        }

        //Kollar ifall spelaren klickar på någon av interactables
        public void CheckClickOnInteractables(List<InteractableGameObject> interactables)
        {
            //Ifall spelaren klickar
            if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
            {
                //Kolla varje interactable
                foreach (InteractableGameObject interactable in interactables)
                {
                    //Ifall musens position är på den interactable, interagera med den och skicka en referens av spelaren
                    if (Raylib.CheckCollisionPointRec(mousePosition, interactable.rec))
                    {
                        interactable.Interact(this);
                        return;
                    }
                }
            }
        }

        //Förenklar att kolla ifall spelaren håller i en ingrediens
        public bool IsHoldingIngredient()
        {
            return heldIngredient != null;
        }
    }
}