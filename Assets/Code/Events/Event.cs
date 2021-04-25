using System;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Events
{
    [Serializable]
    public abstract class Event
    {
        public string name;
        public string description;
        public int TTL;
        public int Cooldown;

        public AudioClip clip;

        public GameObjectManager gmo;

        public virtual void Apply(GameObjectManager gameObjectManager)
        {
            gmo = gameObjectManager;
            gmo.audioSource.PlayOneShot(clip);
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