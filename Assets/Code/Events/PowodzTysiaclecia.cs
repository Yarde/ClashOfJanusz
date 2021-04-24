namespace Code.Events
{
    public class PowodzTysiaclecia : Event
    {
        public PowodzTysiaclecia()
        {
            name = "Powodz Tysiaclecia";
            description = "Kurwa znowu na pola wylało";
        }
        
        public override void Apply(GameObjectManager gameObjectManager)
        {
            base.Apply(gameObjectManager);
            
            TTL = 5;
            Cooldown = 15;

            gmo.Waters.ForEach(x => x.HungerEachTurn = -4);
            gmo.Plants.ForEach(x => x.HungerEachTurn = 6);
        }

        public override void Remove()
        {
            gmo.Waters.ForEach(x => x.HungerEachTurn = -1);
            gmo.Plants.ForEach(x => x.HungerEachTurn = 3);
        }
    }
}