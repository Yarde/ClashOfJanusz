namespace Code.Events
{
    public class FestiwalPiwa : Event
    {
        public FestiwalPiwa()
        {
            name = "Festiwal Piwa";
            description = "Produkcja Harnasia wystrzeliła w kosmos";
        }
        
        public override void Apply(GameObjectManager gameObjectManager)
        {
            base.Apply(gameObjectManager);
            
            TTL = 5;
            Cooldown = 15;
            
            gmo.Waters.ForEach(x => x.HungerEachTurn = 1);
            gmo.Herbivores.ForEach(x => x.HungerOnEat = 140);
        }

        public override void Remove()
        {
            gmo.Waters.ForEach(x => x.HungerEachTurn = -1);
            gmo.Herbivores.ForEach(x => x.HungerOnEat = 140);
        }
    }
}