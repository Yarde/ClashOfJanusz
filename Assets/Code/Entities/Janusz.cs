using System.Collections.Generic;
using UnityEngine;

namespace Code.Entities
{
    public class Janusz : Entity
    {
        public int poziomNajebania;
        private GameObjectManager gmo;
        
        public override void Setup(Vector3 position)
        {
            base.Setup(position);

            poziomNajebania = 0;
            MaxHunger = 200;
            HungerEachTurn = 6;
            HungerOnEat = 100;
            HungerOnReproduce = 100;
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
                gmo.AddHerbivore();
            }
        }

        public void OnClick()
        {
            poziomNajebania += 50;
        }
    }
}
