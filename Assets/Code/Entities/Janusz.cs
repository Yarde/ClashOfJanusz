using System.Collections.Generic;
using UnityEngine;

namespace Code.Entities
{
    public class Janusz : Entity
    {
        public int poziomNajebania;
        private GameObjectManager gmo;

        public float sucharChance;
        
        public override void Setup(Vector3 position)
        {
            base.Setup(position);

            poziomNajebania = 0;

            sucharChance = 0.5f;
        }

        public void SetDependencies(GameObjectManager _gmo)
        {
            gmo = _gmo;
        }

        public override void Resolve()
        {
            poziomNajebania--;

            if (poziomNajebania >= 60)
            {
                if (Random.Range(0.0f, 1.0f) > sucharChance)
                    gmo.Coins += 1;
            }
        }

        public void OnClick()
        {
            poziomNajebania += 50;
        }
    }
}
