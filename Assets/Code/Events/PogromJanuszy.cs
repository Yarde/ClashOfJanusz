using UnityEngine;

namespace Code.Events
{
    public class PogromJanuszy : Event
    {
        public PogromJanuszy()
        {
            name = "Pogrom Januszy";
            description = "Tydzień Somsiada, populacja Januszy zmniejsza się";
            clip = Resources.Load<AudioClip>("Sounds/rain");
        }
        
        public override void Apply(GameObjectManager gameObjectManager)
        {
            base.Apply(gameObjectManager);
            
            TTL = 5;
            Cooldown = 15;
            
            for (var i = 0; i < 5; i++)
            {
                gmo.RemoveJanusz();
            }
        }

        public override void Remove()
        {
        }
    }
}