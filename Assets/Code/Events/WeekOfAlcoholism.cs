using System.Linq;

namespace Code.Events
{
    public class WeekOfAlcoholism : Event
    {
        public override void Apply(GameObjectManager gameObjectManager)
        {
            base.Apply(gameObjectManager);
            
            TTL = 7;
            Cooldown = 20;
            
            gmo.Carnivores.ForEach(x => x.HungerEachTurn = 4);
        }

        public override void Remove()
        {
            gmo.Carnivores.ForEach(x => x.HungerEachTurn = 2);
        }
    }
}