using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Code;
using Code.Entities;
using UnityEngine;
using Random = System.Random;

public class GameObjectManager : MonoBehaviour
{
    public List<Entity> entities = new List<Entity>();

    public List<Carnivore> Carnivores = new List<Carnivore>();
    public List<Herbivore> Herbivores = new List<Herbivore>();
    public List<Plant> Plants = new List<Plant>();
    public List<Water> Waters = new List<Water>();

    private Random random;

    public void Init()
    {
        random = new Random();
        
        for (int i = 0; i < 10; i++)
        {
            Carnivores.Add(new Carnivore());
        }
        
        for (int i = 0; i < 20; i++)
        {
            Herbivores.Add(new Herbivore());
        }
        
        for (int i = 0; i < 50; i++)
        {
            Plants.Add(new Plant());
        }
        
        for (int i = 0; i < 10; i++)
        {
            Waters.Add(new Water());
        }
    }

    public void Resolve()
    {
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
        Plants.RemoveAll(s => s.toKill);
        Herbivores.RemoveAll(s => s.toKill);
        Carnivores.RemoveAll(s => s.toKill);
        Waters.RemoveAll(s => s.toKill);

        Plants.FindAll(x => x.toReproduce).ForEach(x =>
        {
            Plants.Add(new Plant());
            x.Reproduce();
        });
        Herbivores.FindAll(x => x.toReproduce).ForEach(x =>
        {
            Herbivores.Add(new Herbivore());
            x.Reproduce();
        });
        Carnivores.FindAll(x => x.toReproduce).ForEach(x =>
        {
            Carnivores.Add(new Carnivore());
            x.Reproduce();
        });
        Waters.FindAll(x => x.toReproduce && Waters.Count < 100).ForEach(x =>
        {
            Waters.Add(new Water());
            x.Reproduce();
        });
    }
}