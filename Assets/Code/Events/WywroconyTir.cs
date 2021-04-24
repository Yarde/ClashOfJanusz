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
            
            gmo.Harnasie.ForEach(x => x.Hunger += Random.Range(10, 80));
        }

        public override void Remove()
        {
            
        }
    }
}