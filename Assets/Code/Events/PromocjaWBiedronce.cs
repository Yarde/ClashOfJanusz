using UnityEngine;

namespace Code.Events
{
    public class PromocjaWBiedronce : Event
    {
        public PromocjaWBiedronce()
        {
            name = "Promocja W Biedronce";
            description = "Ej! Grażyna! Znowu Harnaś na promocji";
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