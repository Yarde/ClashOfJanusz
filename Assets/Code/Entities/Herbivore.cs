namespace Code.Entities
{
    public class Herbivore : Entity
    {
        public Herbivore() : base()
        {
            MaxHunger = 10;
            HungerEachTurn = 3;
            HungerOnEat = 5;
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
            
                Hunger += 5;
            }
        }
    }
}