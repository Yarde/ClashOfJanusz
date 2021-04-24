namespace Code.Events
{
    public class TydzienTrzezwosci : Event
    {
        public TydzienTrzezwosci()
        {
            name = "Tydzien Trzeźwości";
            description = "Janusz, zostaw to piwo!";
        }
        
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