using UnityEngine;

namespace Code.Events
{
    public class PromocjaWBiedronce : Event
    {
        public PromocjaWBiedronce()
        {
            name = "Promocja W Biedronce";
            description = "Ej! Grażyna! Weź 2 zgrzewki tego Harnaś na promocji";
        }
        
        public override void Apply(GameObjectManager gameObjectManager)
        {
            base.Apply(gameObjectManager);
            
            TTL = 1;
            Cooldown = 15;

            for (var i = 0; i < 12; i++)
            {
                gmo.AddHarnas();
            }
        }

        public override void Remove()
        {
        }
    }
}