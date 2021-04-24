using UnityEngine;

namespace Code.Events
{
    public class RadioaktywnyDeszcz : Event
    {
        public RadioaktywnyDeszcz()
        {
            name = "Radioaktywny Deszcz";
            description = "Z czego teraz zrobimy Harnasia?";
        }
        
        public override void Apply(GameObjectManager gameObjectManager)
        {
            base.Apply(gameObjectManager);
            
            TTL = 1;
            Cooldown = 15;
            
            gmo.Chmiele.ForEach(x => x.Hunger += Random.Range(20, 60));
        }

        public override void Remove()
        {
            
        }
    }
}