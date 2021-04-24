using System;

namespace Code.Events
{
    [Serializable]
    public abstract class Event
    {
        public string name;
        public string description;
        public int TTL;
        public int Cooldown;

        public GameObjectManager gmo;

        public virtual void Apply(GameObjectManager gameObjectManager)
        {
            gmo = gameObjectManager;
        }
        public abstract void Remove();

        public void Update()
        {
            TTL--;
            Cooldown--;
            
            if (TTL == 0)
            {
                Remove();
            }
        }
    }
}