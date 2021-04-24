using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code.Entities
{
    public class Janusz : Entity
    {
        public float poziomNajebania;
        private GameObjectManager gmo;
        public DrunkBar drunkBar;

        public float sucharChance;

        public override void Setup(Vector3 position)
        {
            base.Setup(position);

            poziomNajebania = 70;

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

        private void Update()
        {
            poziomNajebania -= Time.deltaTime * 3;
            drunkBar.level = poziomNajebania;
        }

        public void OnClick()
        {
            if (gmo.TakeHarnas())
            {
                poziomNajebania += 50;
                poziomNajebania = Math.Min(poziomNajebania, 100);
            }
        }
    }
}
