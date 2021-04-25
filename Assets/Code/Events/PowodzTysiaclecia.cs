using UnityEngine;

namespace Code.Events
{
    public class PowodzTysiaclecia : Event
    {
        public PowodzTysiaclecia()
        {
            name = "Powodz Tysiaclecia";
            description = "Kurwa! Apokalipsa!";
            clip = Resources.Load<AudioClip>("janusz");
        }
        
        public override void Apply(GameObjectManager gameObjectManager)
        {
            base.Apply(gameObjectManager);
            
            TTL = 5;
            Cooldown = 15;

            for (var i = 0; i < gmo.Janusze.Count/4; i++)
            {
                gmo.RemoveChmiel();
            }
            
            for (var i = 0; i < gmo.Harnasie.Count/2; i++)
            {
                gmo.RemoveChmiel();
            }
            
            for (var i = 0; i < gmo.Chmiele.Count/3; i++)
            {
                gmo.RemoveChmiel();
            }
        }

        public override void Remove()
        {

        }
    }
}