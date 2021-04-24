using System.Collections.Generic;
using Code.Entities;
using UnityEngine;
using UnityEngine.Serialization;
using Event = Code.Events.Event;
using Random = UnityEngine.Random;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class GameObjectManager : MonoBehaviour
{
    [SerializeField] public Janusz janusz;
    [SerializeField] public Harnas harnas;
    [SerializeField] public Chmiel chmiel;
    [SerializeField] public Water woda;
    [SerializeField] public Transform januszSpawner;
    [SerializeField] public Transform januszWalkYard;
    [SerializeField] public List<Transform> chmielSpawners;
    [SerializeField] public Transform harnasSpawner;

    public List<Janusz> Janusze = new List<Janusz>();
    public List<Harnas> Harnasie = new List<Harnas>();
    public List<Chmiel> Chmiele = new List<Chmiel>();
    //public List<Water> Waters = new List<Water>();

    public List<Event> events = new List<Event>();
    public bool Lost => Janusze.Count == 0 && Harnasie.Count == 0 && Chmiele.Count == 0;
    public int Points => Janusze.Count * 3 + Harnasie.Count * 2 + Chmiele.Count;

    public int Coins { get; set; }

    private System.Random _random = new System.Random();

    public void Reset()
    {
        Chmiele.ForEach(x => Destroy(x.gameObject));
        Harnasie.ForEach(x => Destroy(x.gameObject));
        Janusze.ForEach(x => Destroy(x.gameObject));
        
        Janusze.Clear();
        Harnasie.Clear();
        Chmiele.Clear();
    }

    public void Init()
    {
        Coins = 10;
        
        for (int i = 0; i < 5; i++)
        {
            AddCarnivore();
        }

        // for (int i = 0; i < 20; i++)
        // {
        //     AddHerbivore();
        // }

        for (int i = 0; i < 5; i++)
        {
            AddPlant();
        }
    }

    private Vector3 RandomPointInBoundsList(List<Transform> bounds)
    {
        return RandomPointInBounds(bounds[_random.Next(bounds.Count)]);
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
        return RandomPointInBounds(januszWalkYard);
    }


    public bool Resolve()
    {
        foreach (var e in events)
        {
            e.Update();
        }
        events.RemoveAll(s => s.TTL <= 0 && s.Cooldown <= 0);

        foreach (var p in Chmiele)
        {
            if (Random.Range(0.0f, 1.0f) > 0.5f)
            {
                AddHerbivore();
            }
        }

        // foreach (var p in Chmiele)
        // {
        //     p.Resolve();
        //     //p.Eat(new List<Entity>(Waters));
        // }

        // foreach (var h in Harnasie)
        // {
        //     h.Resolve();
        //     h.Eat(new List<Entity>(Chmiele));
        // }

        // foreach (var c in Janusze)
        // {
        //     c.Resolve();
        //     c.Eat(new List<Entity>(Harnasie));
        // }

        // foreach (var w in Waters)
        // {
        //     w.Resolve();
        // }

       // UpdateEntities();

        Debug.Log($"Janusze: {Janusze.Count} Harnasie: {Harnasie.Count} Chmiele: {Chmiele.Count}");// Waters: {Waters.Count} ");
        return Lost;
    }

    private void UpdateEntities()
    {
        //Chmiele.FindAll(x => x.toKill).ForEach(x => Destroy(x.gameObject));
        //Harnasie.FindAll(x => x.toKill).ForEach(x => Destroy(x.gameObject));
        //Janusze.FindAll(x => x.toKill).ForEach(x => Destroy(x.gameObject));
        //Waters.FindAll(x => x.toKill).ForEach(x => Destroy(x.gameObject));

        //Chmiele.RemoveAll(s => s.toKill);
        //Harnasie.RemoveAll(s => s.toKill);
        //Janusze.RemoveAll(s => s.toKill);
        //Waters.RemoveAll(s => s.toKill);

        // Chmiele.FindAll(x => x.toReproduce).ForEach(x =>
        // {
        //     AddPlant();
        //     //x.Reproduce();
        // });
        // Harnasie.FindAll(x => x.toReproduce).ForEach(x =>
        // {
        //     AddHerbivore();
        //     x.Reproduce();
        // });
        // Janusze.FindAll(x => x.toReproduce).ForEach(x =>
        // {
        //     AddCarnivore();
        //     x.Reproduce();
        // });
        // Waters.FindAll(x => x.toReproduce && Waters.Count < 100).ForEach(x =>
        // {
        //     AddWater();
        //     x.Reproduce();
        // });
    }

    public void AddCarnivore()
    {
        var c = Instantiate(janusz, transform);
        c.Setup(RandomPointInBounds(januszSpawner));
        c.SetDependencies(this);
        Janusze.Add(c);
    }

    public void AddHerbivore()
    {
        var c = Instantiate(harnas, transform);
        c.Setup(RandomPointInBounds(harnasSpawner));
        Harnasie.Add(c);
    }

    public void AddPlant()
    {
        var c = Instantiate(chmiel, transform);
        c.Setup(RandomPointInBoundsList(chmielSpawners));
        Chmiele.Add(c);
    }

    // public void AddWater()
    // {
    //     var c = Instantiate(woda, transform);
    //     c.Setup(RandomPointInBounds(januszBounds));
    //     Waters.Add(c);
    // }

    public void RemoveCarnivore()
    {
        var index = Random.Range(0, Janusze.Count);
        Janusze.RemoveAt(index);
    }
}
