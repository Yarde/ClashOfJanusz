namespace Code.Entities
{
    public class Water : Entity
    {
        public override void Setup()
        {
            MaxHunger = 200;
            HungerEachTurn = -1;
            HungerOnReproduce = 100;
        }
    }
}