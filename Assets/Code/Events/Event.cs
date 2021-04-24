namespace Code.Events
{
    public abstract class Event
    {
        public int TTL;

        public GameObjectManager gmo;

        public virtual void Apply(GameObjectManager gameObjectManager)
        {
            gmo = gameObjectManager;
        }
        public abstract void Remove();

        public void Update()
        {
            TTL--;
            
            if (TTL == 0)
            {
                Remove();
            }
        }
    }
}