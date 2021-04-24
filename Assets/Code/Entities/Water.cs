namespace Code.Entities
{
    public class Water : Entity
    {
        public Water() : base()
        {
            MaxHunger = 20;
            HungerEachTurn = -1;
        }
        
        public override void Resolve()
        {
            base.Resolve();
            
            if (Hunger > MaxHunger)
            {
                toKill = true;
            }
            
            if (Hunger < 0)
            {
                toReproduce = true;
            }
        }
        
        public override void Reproduce()
        {
            if (toReproduce)
            {
                base.Reproduce();
            
                Hunger += 10;
            }
        }
    }
}