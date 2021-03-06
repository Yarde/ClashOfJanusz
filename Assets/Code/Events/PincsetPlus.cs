using UnityEngine;

namespace Code.Events
{
    public class PincsetPlus : Event
    {
        public PincsetPlus()
        {
            name = "Pinćset Plus";
            description = "Kto Ci na starość szklankę wody poda?\n+2 Januszy";
            clip = Resources.Load<AudioClip>("Sounds/plus");
        }
        
        public override void Apply(GameObjectManager gameObjectManager)
        {
            base.Apply(gameObjectManager);

            TTL = 1;
            Cooldown = 999;

            for (var i = 0; i < 2; i++)
            {
                gmo.AddJanusz();
            }
        }

        public override void Remove()
        {
        }
    }
}