namespace Code.Events
{
    public class OkresGodowy : Event
    {
        public OkresGodowy()
        {
            name = "Okres Godowy";
            description = "Pieter mój synu!";
        }
        
        public override void Apply(GameObjectManager gameObjectManager)
        {
            base.Apply(gameObjectManager);
            
            TTL = 5;
            Cooldown = 15;
            
            gmo.Carnivores.ForEach(x => x.HungerOnEat = 150);
            gmo.Herbivores.ForEach(x => x.HungerEachTurn = 6);
        }

        public override void Remove()
        {
            gmo.Carnivores.ForEach(x => x.HungerOnEat = 100);
            gmo.Herbivores.ForEach(x => x.HungerEachTurn = 3);
        }
    }
}