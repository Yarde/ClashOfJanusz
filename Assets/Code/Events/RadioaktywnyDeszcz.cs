using UnityEngine;

namespace Code.Events
{
    public class RadioaktywnyDeszcz : Event
    {
        public RadioaktywnyDeszcz()
        {
            name = "Radioaktywny Deszcz";
            clip = Resources.Load<AudioClip>("Sounds/rain");
        }
        
        public override void Apply(GameObjectManager gameObjectManager)
        {
            base.Apply(gameObjectManager);
            
            TTL = 1;
            Cooldown = 999;
            description = $"Z czego teraz zrobimy Harnasia?\n+{gmo.Chmiele.Count/2} Chmielu";
            
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