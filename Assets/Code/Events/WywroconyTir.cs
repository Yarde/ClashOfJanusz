using UnityEngine;

namespace Code.Events
{
    public class WywroconyTir : Event
    {
        public WywroconyTir()
        {
            name = "Wywrocony Tir";
            clip = Resources.Load<AudioClip>("Sounds/carCrash");
        }
        
        public override void Apply(GameObjectManager gameObjectManager)
        {
            base.Apply(gameObjectManager);
            
            TTL = 1;
            Cooldown = 999;
            description = $"Żałoba narodowa, cała dostawa zmarnowana\n-{gmo.Harnasie.Count} Harnasia";

            for (var i = 0; i < gmo.Harnasie.Count; i++)
            {
                gmo.RemoveHarnas();
            }
        }

        public override void Remove()
        {
            
        }
    }
}