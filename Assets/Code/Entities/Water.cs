namespace Code.Entities
{
    public class Water : Entity
    {
        public Water() : base()
        {
            MaxHunger = 200;
            HungerEachTurn = -1;
            HungerOnReproduce = 100;
        }
    }
}