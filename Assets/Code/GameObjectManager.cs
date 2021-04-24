using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Code;
using Code.Entities;
using UnityEngine;
using Event = Code.Events.Event;
using Random = System.Random;

public class GameObjectManager : MonoBehaviour
{
    [SerializeField] public Carnivore janusz;
    [SerializeField] public Herbivore harnas;
    [SerializeField] public Plant chmiel;
    [SerializeField] public Water woda;

    public List<Carnivore> Carnivores = new List<Carnivore>();
    public List<Herbivore> Herbivores = new List<Herbivore>();
    public List<Plant> Plants = new List<Plant>();
    public List<Water> Waters = new List<Water>();
    
    public List<Event> events = new List<Event>();
    public bool Lost => Carnivores.Count == 0 && Herbivores.Count == 0 && Plants.Count == 0;
    public int Points => Carnivores.Count * 3 + Herbivores.Count * 2 + Plants.Count;

    public void Init()
    {
        for (int i = 0; i < 10; i++)
        {
            AddCarnivore();
        }
        
        for (int i = 0; i < 20; i++)
        {
            AddHerbivore();
        }
        
        for (int i = 0; i < 50; i++)
        {
            AddPlant();
        }
        
        for (int i = 0; i < 100; i++)
        {
            AddWater();
        }
    }

    public bool Resolve()
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
        return Lost;
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
            AddPlant();
            x.Reproduce();
        });
        Herbivores.FindAll(x => x.toReproduce).ForEach(x =>
        {
            AddHerbivore();
            x.Reproduce();
        });
        Carnivores.FindAll(x => x.toReproduce).ForEach(x =>
        {
            AddCarnivore();
            x.Reproduce();
        });
        Waters.FindAll(x => x.toReproduce && Waters.Count < 100).ForEach(x =>
        {
            AddWater();
            x.Reproduce();
        });
    }

    public void AddCarnivore()
    {
        var c = Instantiate(janusz, transform);
        c.Setup();
        Carnivores.Add(c);
    }
    
    public void AddHerbivore()
    {
        var c = Instantiate(harnas, transform);
        c.Setup();
        Herbivores.Add(c);
    }
    
    public void AddPlant()
    {
        var c = Instantiate(chmiel, transform);
        c.Setup();
        Plants.Add(c);
    }
    
    public void AddWater()
    {
        var c = Instantiate(woda, transform);
        c.Setup();
        Waters.Add(c);
    }
}