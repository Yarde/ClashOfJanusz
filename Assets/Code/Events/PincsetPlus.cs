using UnityEngine;

namespace Code.Events
{
    public class PincsetPlus : Event
    {
        public PincsetPlus()
        {
            name = "Pinćset Plus";
            description = "Kto Ci na starość szklankę wody poda?";
        }
        
        public override void Apply(GameObjectManager gameObjectManager)
        {
            base.Apply(gameObjectManager);

            TTL = 1;
            Cooldown = 15;

            gmo.Carnivores.ForEach(x => x.Hunger = Random.Range(0, 10));
        }

        public override void Remove()
        {
        }
    }
}