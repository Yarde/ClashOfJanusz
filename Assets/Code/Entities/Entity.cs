using System;
using System.Collections.Generic;
using UnityEditor.VersionControl;

namespace Code.Entities
{
    public abstract class Entity
    {
        public int Hunger;
        public int MaxHunger;
        public int HungerEachTurn;
        public int HungerOnEat;
        public bool toKill;
        public bool toReproduce;
        private Random random = new Random();

        public Entity()
        {
            Hunger = 0;
            toKill = false;
            toReproduce = false;
        }

        public virtual void Resolve()
        {
            Hunger += HungerEachTurn;
        }

        public virtual void Reproduce()
        {
            toReproduce = false;
        }

        public virtual void Eat(List<Entity> entities)
        {
            if (Hunger/(float)MaxHunger < random.NextDouble())
            {
                return;
            }
            
            if (!toKill && !toReproduce && entities.Count > 0)
            {
                int index = random.Next(entities.Count);

                entities[index].toKill = true;
                
                Hunger -= HungerOnEat;
            }
        }
    }
}