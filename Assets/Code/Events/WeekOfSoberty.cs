namespace Code.Events
{
    public class WeekOfSoberty : Event
    {
        public override void Apply(GameObjectManager gameObjectManager)
        {
            base.Apply(gameObjectManager);
            
            TTL = 7;
            Cooldown = 20;
            
            gmo.Carnivores.ForEach(x => x.HungerEachTurn = 0);
        }

        public override void Remove()
        {
            gmo.Carnivores.ForEach(x => x.HungerEachTurn = 2);
        }
    }
}