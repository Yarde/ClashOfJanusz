using System.Collections.Generic;

namespace Code.Entities
{
    public class Carnivore : Entity
    {
        public Carnivore() : base()
        {
            MaxHunger = 20;
            HungerEachTurn = 2;
            HungerOnEat = 10;
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
            
                Hunger += 10;
            }
        }
    }
}
