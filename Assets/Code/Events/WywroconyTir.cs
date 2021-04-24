using UnityEngine;

namespace Code.Events
{
    public class WywroconyTir : Event
    {
        public WywroconyTir()
        {
            name = "Wywrocony Tir";
            description = "Żałoba narodowa, cała dostawa zmarnowana";
        }
        
        public override void Apply(GameObjectManager gameObjectManager)
        {
            base.Apply(gameObjectManager);
            
            TTL = 1;
            Cooldown = 15;

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