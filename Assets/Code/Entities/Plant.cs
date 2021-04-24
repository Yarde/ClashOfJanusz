using System;
using System.Collections.Generic;

namespace Code.Entities
{
    public class Plant : Entity
    {
        public Plant() : base()
        {
            MaxHunger = 10;
            HungerEachTurn = 3;
            HungerOnEat = 4;
        }
        
        public override void Resolve()
        {
            base.Resolve();
            
            if (Hunger > MaxHunger)
            {
                toKill = true;
            }
            
            if (Hunger < 0)
            {
                toReproduce = true;
            }
        }
        
        public override void Reproduce()
        {
            if (toReproduce)
            {
                base.Reproduce();
            
                Hunger += 5;
            }
        }

        public override void Eat(List<Entity> waters)
        {
            var random = new Random();
            
            if (Hunger/(float)MaxHunger < random.NextDouble())
            {
                return;
            }
            
            if (!toKill && !toReproduce && waters.Count > 0)
            {
                
                int index = random.Next(waters.Count);

                waters[index].Hunger += 6;

                Hunger -= HungerOnEat;
            }
        }
    }
}