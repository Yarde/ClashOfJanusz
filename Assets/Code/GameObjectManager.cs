﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using Code;
using Code.Entities;
using UnityEngine;
using Event = Code.Events.Event;
using Random = UnityEngine.Random;

public class GameObjectManager : MonoBehaviour
{
    [SerializeField] public Carnivore janusz;
    [SerializeField] public Herbivore harnas;
    [SerializeField] public Plant chmiel;
    [SerializeField] public Water woda;
    [SerializeField] public Transform januszBounds;

    public List<Carnivore> Carnivores = new List<Carnivore>();
    public List<Herbivore> Herbivores = new List<Herbivore>();
    public List<Plant> Plants = new List<Plant>();
    public List<Water> Waters = new List<Water>();
    
    public List<Event> events = new List<Event>();

    public void Init()
    {
        for (int i = 0; i < 10; i++)
        {
            var c = Instantiate(janusz, transform);
            c.Setup(RandomPointInBounds(januszBounds));
            Carnivores.Add(c);
        }
        
        for (int i = 0; i < 20; i++)
        {
            var h = Instantiate(harnas, transform);
            h.Setup(RandomPointInBounds(januszBounds));
            Herbivores.Add(h);
        }
        
        for (int i = 0; i < 50; i++)
        {
            var p = Instantiate(chmiel, transform);
            p.Setup(RandomPointInBounds(januszBounds));
            Plants.Add(p);
        }
        
        for (int i = 0; i < 100; i++)
        {
            var w = Instantiate(woda, transform);
            w.Setup(RandomPointInBounds(januszBounds));
            Waters.Add(w);
        }
    }
    
    public static Vector3 RandomPointInBounds(Transform bounds)
    {
        Vector2 location = Random.insideUnitCircle;
        location.x *= bounds.localScale.x / 2;
        location.y *= bounds.localScale.y / 2;
        location.x += bounds.position.x;
        location.y += bounds.position.z;
        return new Vector3(location.x, 0, location.y);
    }

    public Vector3 RandomJanuszWanderPoint()
    {
        return RandomPointInBounds(januszBounds);
    }


    public void Resolve()
    {
        foreach (var e in events)
        {
            e.Update();
        }
        events.RemoveAll(s => s.TTL <= 0 && s.Cooldown <= 0);
        
        foreach (var p in Plants)
        {
            p.Resolve();
            p.Eat(new List<Entity>(Waters));
        }

        foreach (var h in Herbivores)
        {
            h.Resolve();
            h.Eat(new List<Entity>(Plants));
        }

        foreach (var c in Carnivores)
        {
            c.Resolve();
            c.Eat(new List<Entity>(Herbivores));
        }

        foreach (var w in Waters)
        {
            w.Resolve();
        }

        UpdateEntities();
        
        Debug.Log($"Carnivores: {Carnivores.Count} Herbivores: {Herbivores.Count} Plants: {Plants.Count} Waters: {Waters.Count} ");
    }

    private void UpdateEntities()
    {
        Plants.FindAll(x => x.toKill).ForEach(x => Destroy(x.gameObject));
        Herbivores.FindAll(x => x.toKill).ForEach(x => Destroy(x.gameObject));
        Carnivores.FindAll(x => x.toKill).ForEach(x => Destroy(x.gameObject));
        Waters.FindAll(x => x.toKill).ForEach(x => Destroy(x.gameObject));
        
        Plants.RemoveAll(s => s.toKill);
        Herbivores.RemoveAll(s => s.toKill);
        Carnivores.RemoveAll(s => s.toKill);
        Waters.RemoveAll(s => s.toKill);

        Plants.FindAll(x => x.toReproduce).ForEach(x =>
        {
            var p = Instantiate(chmiel, transform);
            p.Setup(RandomPointInBounds(januszBounds));
            Plants.Add(p);
            x.Reproduce();
        });
        Herbivores.FindAll(x => x.toReproduce).ForEach(x =>
        {
            var h = Instantiate(harnas, transform);
            h.Setup(RandomPointInBounds(januszBounds));
            Herbivores.Add(h);
            x.Reproduce();
        });
        Carnivores.FindAll(x => x.toReproduce).ForEach(x =>
        {
            var c = Instantiate(janusz, transform);
            c.Setup(RandomPointInBounds(januszBounds));
            Carnivores.Add(c);
            x.Reproduce();
        });
        Waters.FindAll(x => x.toReproduce && Waters.Count < 100).ForEach(x =>
        {
            var w = Instantiate(woda, transform);
            w.Setup(RandomPointInBounds(januszBounds));
            Waters.Add(w);
            x.Reproduce();
        });
    }
}