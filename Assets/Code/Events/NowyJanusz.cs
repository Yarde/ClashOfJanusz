using UnityEngine;
using UnityEngine.UI;

namespace Code.Events
{
    public class NowyJanusz : Event
    {
        public NowyJanusz()
        {
            name = "Nowe życie";
            description = "Pieter mój synu!";
            clip = Resources.Load<AudioClip>("Sounds/janusz");
        }
        
        public override void Apply(GameObjectManager gameObjectManager)
        {
            base.Apply(gameObjectManager);
            
            TTL = 1;
            Cooldown = 0;
            
            gmo.AddJanusz();
        }

        public override void Remove()
        {
        }
    }
}