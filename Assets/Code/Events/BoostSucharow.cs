namespace Code.Events
{
    public class BoostSucharow : Event
    {
        public BoostSucharow()
        {
            name = "Komplement";
            description = "Produkcja Harnasia wystrzeliła w kosmos";
        }
        
        public override void Apply(GameObjectManager gameObjectManager)
        {
            base.Apply(gameObjectManager);
            
            TTL = 7;
            Cooldown = 7;
            
            for (var i = 0; i < 5; i++)
            {
                gmo.AddHarnas();
            }
            gmo.Janusze.ForEach(x => x.sucharChance = 0.8f);
        }

        public override void Remove()
        {
            gmo.Janusze.ForEach(x => x.sucharChance = 0.5f);
        }
    }
}