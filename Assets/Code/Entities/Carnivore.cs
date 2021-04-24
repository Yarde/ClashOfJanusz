using System.Collections.Generic;

namespace Code.Entities
{
    public class Carnivore : Entity
    {
        public Carnivore() : base()
        {
            MaxHunger = 200;
            HungerEachTurn = 2;
            HungerOnEat = 100;
            HungerOnReproduce = 100;
        }
    }
}
