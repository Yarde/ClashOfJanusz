using System.Collections.Generic;

namespace Code.Entities
{
    public class Carnivore : Entity
    {
        public override void Setup()
        {
            base.Setup();
            
            MaxHunger = 200;
            HungerEachTurn = 2;
            HungerOnEat = 100;
            HungerOnReproduce = 100;
        }
    }
}
