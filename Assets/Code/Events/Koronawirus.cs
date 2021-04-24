﻿namespace Code.Events
{
    public class Koronawirus : Event
    {
        public Koronawirus()
        {
            name = "Koronawirus";
            description = "Janusze siedzą w domach, rośliny ożywają";
        }
        
        public override void Apply(GameObjectManager gameObjectManager)
        {
            base.Apply(gameObjectManager);
            
            TTL = 5;
            Cooldown = 15;
            
            gmo.Janusze.ForEach(x => x.HungerEachTurn = 5);
            gmo.Chmiele.ForEach(x => x.HungerEachTurn = 0);
        }

        public override void Remove()
        {
            gmo.Janusze.ForEach(x => x.HungerEachTurn = 2);
            gmo.Chmiele.ForEach(x => x.HungerEachTurn = 3);
        }
    }
}