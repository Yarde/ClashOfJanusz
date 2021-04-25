namespace Code.Events
{
    public class TydzienTrzezwosci : Event
    {
        public TydzienTrzezwosci()
        {
            name = "Tydzien Trzeźwości";
            description = "Janusz, zostaw to piwo i  skończ z tymi sucharami!\nJanusze nie okowiadają sucharów przez 7 sek";
        }
        
        public override void Apply(GameObjectManager gameObjectManager)
        {
            base.Apply(gameObjectManager);
            
            TTL = 7;
            Cooldown = 999;

            gmo.Janusze.ForEach(x => x.sucharChance = 0.0f);
        }

        public override void Remove()
        {
            gmo.Janusze.ForEach(x => x.sucharChance = 0.005f);
        }
    }
}