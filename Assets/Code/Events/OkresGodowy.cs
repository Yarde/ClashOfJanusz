using UnityEngine;

namespace Code.Events
{
    public class OkresGodowy : Event
    {
        public OkresGodowy()
        {
            name = "Okres Godowy";
            description = "Pieter mój synu!";
        }
        
        public override void Apply(GameObjectManager gameObjectManager)
        {
            base.Apply(gameObjectManager);
            
            TTL = 5;
            Cooldown = 15;
            
            for (var i = 0; i < 3; i++)
            {
                gmo.AddCarnivore();
            }
            
            //gmo.Janusze.ForEach(x => x.HungerOnEat = 150);
            //gmo.Janusze.ForEach(x => x.Hunger -= Random.Range(10, 60));
            gmo.Harnasie.ForEach(x => x.HungerEachTurn = 6);
        }

        public override void Remove()
        {
            //gmo.Janusze.ForEach(x => x.HungerOnEat = 100);
            gmo.Harnasie.ForEach(x => x.HungerEachTurn = 3);
        }
    }
}