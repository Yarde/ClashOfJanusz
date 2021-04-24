namespace Code.Entities
{
    public class Herbivore : Entity
    {
        public override void Setup()
        {
            base.Setup();

            MaxHunger = 100;
            HungerEachTurn = 3;
            HungerOnEat = 50;
            HungerOnReproduce = 50;
        }
    }
}