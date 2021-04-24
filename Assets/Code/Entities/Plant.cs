using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code.Entities
{
    public class Plant : Entity
    {
        public Plant() : base()
        {
            MaxHunger = 100;
            HungerEachTurn = 3;
            HungerOnEat = 20;
            HungerOnReproduce = 50;
        }

        public override void Eat(List<Entity> waters)
        {
            var a = Hunger / (float) MaxHunger;
            var b = Random.Range(0.1f, 0.5f);
            
            if (a<b)
            {
                return;
            }
            
            if (!toKill && !toReproduce && waters.Count > 0)
            {
                
                int index = Random.Range(0, waters.Count);

                waters[index].Hunger += 20;

                Hunger -= HungerOnEat;
            }
        }
    }
}