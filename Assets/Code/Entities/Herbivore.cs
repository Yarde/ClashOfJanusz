namespace Code.Entities
{
    public class Herbivore : Entity
    {
        public Herbivore() : base()
        {
            MaxHunger = 100;
            HungerEachTurn = 3;
            HungerOnEat = 50;
            HungerOnReproduce = 50;
        }
    }
}