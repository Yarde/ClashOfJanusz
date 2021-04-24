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
            
            for (var i = 0; i < gmo.Chmiele.Count/2; i++)
            {
                gmo.RemoveChmiel();
            }
        }

        public override void Remove()
        {
            
        }
    }
}