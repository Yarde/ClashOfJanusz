using System.Collections.Generic;
using UnityEngine;

namespace Code.Entities
{
    public class Carnivore : Entity
    {
        public override void Setup(Vector3 position)
        {
            base.Setup(position);
            
            MaxHunger = 200;
            HungerEachTurn = 6;
            HungerOnEat = 100;
            HungerOnReproduce = 100;
        }
    }
}
