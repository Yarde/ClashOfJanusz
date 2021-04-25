using UnityEngine;

namespace Code.Events
{
    public class NowyChmiel : Event
    {
        public NowyChmiel()
        {
            name = "Nowy Chmiel";
            description = "Janusze siedzą w domach, rośliny ożywają";
            //todo
            clip = Resources.Load<AudioClip>("janusz");
        }
        
        public override void Apply(GameObjectManager gameObjectManager)
        {
            base.Apply(gameObjectManager);

            TTL = 1;
            Cooldown = 1;
            
            gmo.AddChmiel();
        }

        public override void Remove()
        {
        }
    }
}