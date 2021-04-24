using System.Linq;
using UnityEngine;

namespace Code.Events
{
    public class TydzienAlkoholizmu : Event
    {
        public TydzienAlkoholizmu()
        {
            name = "Tydzień Alkoholizmu";
            description = "Hehe, Grażyny nie ma w domu, pijemy!";
        }
        
        public override void Apply(GameObjectManager gameObjectManager)
        {
            base.Apply(gameObjectManager);
            
            TTL = 7;
            Cooldown = 20;
            
            for (var i = 0; i < gmo.Harnasie.Count; i++)
            {
                gmo.RemoveHarnas();
            }
            
            gmo.Chmiele.ForEach(x => x.ChanceForHarnas += Random.Range(0.3f, 0.5f));
        }

        public override void Remove()
        {
            gmo.Chmiele.ForEach(x => x.ChanceForHarnas = 0.3f);
        }
    }
}