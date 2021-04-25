using UnityEngine;

namespace Code.Events
{
    public class NowaFabrykaHarnasia : Event
    {
        public NowaFabrykaHarnasia()
        {
            name = "Nowa Fabryka Harnasia";
            description = "Produkcja na maksa, fabryka wytrzyma!";
            clip = Resources.Load<AudioClip>("Sounds/fanfary");
        }
        
        public override void Apply(GameObjectManager gameObjectManager)
        {
            base.Apply(gameObjectManager);
            
            TTL = 5;
            Cooldown = 15;
            
            gmo.Chmiele.ForEach(x => x.ChanceForHarnas += Random.Range(0.1f, 0.4f));
        }

        public override void Remove()
        {
            gmo.Chmiele.ForEach(x => x.ChanceForHarnas = 0.3f);
        }
    }
}