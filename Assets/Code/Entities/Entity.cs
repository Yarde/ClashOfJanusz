using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

namespace Code.Entities
{
    public abstract class Entity : MonoBehaviour
    {
        public int Hunger;
        public int MaxHunger;
        public int HungerEachTurn;
        public int HungerOnEat;
        public int HungerOnReproduce;
        public bool toKill;
        public bool toReproduce;

        public virtual void Setup()
        {
            transform.position = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(5.0f, 15.0f));
            
            Hunger = 0;
            toKill = false;
            toReproduce = false;
        }

        public virtual void Resolve()
        {
            Hunger += HungerEachTurn;
            
            if (Hunger > MaxHunger)
            {
                toKill = true;
            }
            
            if (Hunger < 0)
            {
                toReproduce = true;
                Hunger = 0;
            }
        }

        public virtual void Reproduce()
        {
            if (toReproduce)
            {
                toReproduce = false;
                Hunger += HungerOnReproduce;
            }
        }

        public virtual void Eat(List<Entity> entities)
        {
            var a = Hunger / (float) MaxHunger;
            var b = Random.Range(0.4f, 0.8f);

            if (a<b)
            {
                return;
            }
            
            if (!toKill && !toReproduce && entities.Count > 0)
            {
                int index = Random.Range(0, entities.Count);

                entities[index].toKill = true;
                
                Hunger -= HungerOnEat;
            }
        }
    }
}