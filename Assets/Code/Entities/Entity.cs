using System.Collections.Generic;
using UnityEngine;

namespace Code.Entities
{
    public abstract class Entity : MonoBehaviour
    {
        public float ChanceForHarnas;

        public virtual void Setup(Vector3 position)
        {
            transform.position = position;
        }

        public virtual void Resolve()
        {
        }
    }
}