using UnityEngine;

namespace Code.Events
{
    public class NowaFabrykaHarnasia : Event
    {
        public NowaFabrykaHarnasia()
        {
            name = "Nowa Fabryka Harnasia";
            description = "Popyt rodzi podaż";
        }
        
        public override void Apply(GameObjectManager gameObjectManager)
        {
            base.Apply(gameObjectManager);
            
            TTL = 1;
            Cooldown = 15;
            
            gmo.Herbivores.ForEach(x => x.Hunger = Random.Range(0, 10));
        }

        public override void Remove()
        {
            
        }
    }
}