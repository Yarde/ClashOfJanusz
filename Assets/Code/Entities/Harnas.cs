using UnityEngine;

namespace Code.Entities
{
    public class Harnas : Entity
    {
        public override void Setup(Vector3 position)
        {
            base.Setup(position);

            MaxHunger = 100;
            HungerEachTurn = 3;
            HungerOnEat = 50;
            HungerOnReproduce = 50;
        }
    }
}