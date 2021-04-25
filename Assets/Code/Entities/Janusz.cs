using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Code.Entities
{
    public class Janusz : Entity
    {
        public float poziomNajebania;
        private GameObjectManager gmo;
        public DrunkBar drunkBar;

        public float sucharChance;

        public float sucharTime = -1;
        public GameObject speechBubble;
        
        public override void Setup(Vector3 position)
        {
            base.Setup(position);

            poziomNajebania = 70;

            sucharChance = 0.005f;
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
            poziomNajebania -= Time.deltaTime * 5;
            poziomNajebania = Math.Max(0, poziomNajebania);
            drunkBar.level = poziomNajebania;
            if (sucharTime > 0 && Time.time > sucharTime)
            {
                speechBubble.SetActive(false);
                gmo.SpawnSuchar(transform);
                sucharTime = -1;
            }
            else
            {
                CheckForSuchar();
            }
        }

        private void CheckForSuchar()
        {
            if (poziomNajebania > 60 && Random.value < sucharChance)
            {
                sucharTime = Time.time + 1;
                speechBubble.SetActive(true);
            }
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
