using System;
using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;

namespace CookingGame
{
    //Spelaren som egentligen bara representerar musen, den har ett inventory för 1 ingrediens och kan interagera med interactablegameobjects
    public class Player
    {
        public Vector2 position;

        public FoodObject heldFood = null;

        public void Update()
        {
            //Updatera spelarens (musens) position
            position = Raylib.GetMousePosition();
            //Flytta ingrediensen som spelaren håller i till musen
            if (IsHoldingIngredient())
            {
                heldFood.MoveTo(position.X, position.Y);
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
                    if (Raylib.CheckCollisionPointRec(position, interactable.rec))
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
            return heldFood != null;
        }
    }
}