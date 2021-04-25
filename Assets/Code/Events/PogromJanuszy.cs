using UnityEngine;

namespace Code.Events
{
    public class PogromJanuszy : Event
    {
        public PogromJanuszy()
        {
            name = "Pogrom Januszy";
            description = "Tydzień Somsiada, populacja Januszy zmniejsza się\n-2 Januszy";
            clip = Resources.Load<AudioClip>("Sounds/rain");
        }
        
        public override void Apply(GameObjectManager gameObjectManager)
        {
            base.Apply(gameObjectManager);
            
            TTL = 5;
            Cooldown = 999;
            
            for (var i = 0; i < 2; i++)
            {
                gmo.RemoveJanusz();
            }
        }

        public override void Remove()
        {
        }
    }
}