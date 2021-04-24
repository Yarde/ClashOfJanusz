using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code.Entities
{
    public class Chmiel : Entity
    {
        public override void Setup(Vector3 position)
        {
            base.Setup(position);

            ChanceForHarnas = 0.3f;
        }
    }
}