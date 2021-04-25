using UnityEngine;

namespace Code.Events
{
    public class BoostSucharow : Event
    {
        public BoostSucharow()
        {
            name = "Komplement";
            description = "Produkcja Harnasia wystrzeliła w kosmos";
            clip = Resources.Load<AudioClip>("Sounds/pong");
        }
        
        public override void Apply(GameObjectManager gameObjectManager)
        {
            base.Apply(gameObjectManager);
            
            TTL = 7;
            Cooldown = 7;
            
            gmo.Janusze.ForEach(x => x.sucharChance = 0.01f);
        }

        public override void Remove()
        {
            gmo.Janusze.ForEach(x => x.sucharChance = 0.005f);
        }
    }
}