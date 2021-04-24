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
            
            for (var i = 0; i < 5; i++)
            {
                gmo.AddHerbivore();
            }
            
            gmo.Chmiele.ForEach(x => x.HungerEachTurn = 8);
            //gmo.Harnasie.ForEach(x => x.HungerOnEat = 140);
        }

        public override void Remove()
        {
            gmo.Chmiele.ForEach(x => x.HungerEachTurn = 3);
            //gmo.Harnasie.ForEach(x => x.HungerOnEat = 140);
        }
    }
}