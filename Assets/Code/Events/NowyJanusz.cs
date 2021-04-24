using UnityEngine;

namespace Code.Events
{
    public class NowyJanusz : Event
    {
        public NowyJanusz()
        {
            name = "Nowe życie";
            description = "Pieter mój synu!";
        }
        
        public override void Apply(GameObjectManager gameObjectManager)
        {
            base.Apply(gameObjectManager);
            
            TTL = 1;
            Cooldown = 3;
            
            gmo.AddJanusz();
        }

        public override void Remove()
        {
        }
    }
}