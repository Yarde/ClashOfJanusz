using UnityEngine;

namespace Code.Entities
{
    public class Water : Entity
    {
        public override void Setup(Vector3 position)
        {
            base.Setup(position);

            transform.position = new Vector3(Random.Range(13.0f, 15.0f), 0, Random.Range(-8.0f, -5.0f));
            
            MaxHunger = 200;
            HungerEachTurn = -1;
            HungerOnReproduce = 100;
        }
    }
}