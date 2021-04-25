using System;
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
    [SerializeField] public Canvas canvas;
    [SerializeField] public AudioSource audioSource;
    
    [SerializeField] public Janusz janusz;
    [SerializeField] public Harnas harnas;
    [SerializeField] public Chmiel chmiel;
    [SerializeField] public Suchar suchar;
    [SerializeField] public Water woda;
    [SerializeField] public Transform januszSpawner;
    [SerializeField] public Transform januszWalkYard;
    [SerializeField] public List<Transform> chmielSpawners;
    [SerializeField] public Transform harnasSpawner;
    [SerializeField] public Camera camera;

    public List<Janusz> Janusze = new List<Janusz>();
    public List<Harnas> Harnasie = new List<Harnas>();
    public List<Chmiel> Chmiele = new List<Chmiel>();

    public List<Suchar> Suchary = new List<Suchar>();
    //public List<Water> Waters = new List<Water>();

    public List<Event> events = new List<Event>();
    private Boolean _inited = false;
    public bool Lost => Janusze.Count == 0 && Harnasie.Count == 0 && Chmiele.Count == 0;
    public int Points => Janusze.Count * 3 + Harnasie.Count * 2 + Chmiele.Count;
    private float _lastChmielResolve = 0;

    public int Coins { get; set; }

    private System.Random _random = new System.Random();

    public void Reset()
    {
        Chmiele.ForEach(x => Destroy(x.gameObject));
        Harnasie.ForEach(x => Destroy(x.gameObject));
        Janusze.ForEach(x => Destroy(x.gameObject));
        Suchary.ForEach(x => Destroy(x.gameObject));
        
        Janusze.Clear();
        Harnasie.Clear();
        Chmiele.Clear();
        Suchary.Clear();
    }

    public void Init()
    {
        if (_inited || transform.localScale.x < 1)
        {
            return;
        }
        audioSource.volume = 0.6f;
        Coins = 10;
        
        for (int i = 0; i < 5; i++)
        {
            AddJanusz();
        }

        for (int i = 0; i < 5; i++)
        {
            AddChmiel();
        }
        //canvas.gameObject.SetActive(true);

        _inited = true;
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
        // if (!_inited)
        // {
        //     return false;
        // }

        foreach (var e in events)
        {
            e.Update();
        }
        events.RemoveAll(s => s.TTL <= 0 && s.Cooldown <= 0);

        if (_lastChmielResolve + 5.0 < Time.time)
        {
            foreach (var p in Chmiele)
            {
                if (Random.Range(0.0f, 1.0f) > p.ChanceForHarnas)
                {
                    AddHarnas();
                }
            }
            _lastChmielResolve = Time.time;
        }

        Debug.Log($"Janusze: {Janusze.Count} Harnasie: {Harnasie.Count} Chmiele: {Chmiele.Count}");// Waters: {Waters.Count} ");
        return Lost;
    }

    public void AddJanusz()
    {
        var c = Instantiate(janusz, transform);
        c.Setup(RandomPointInBounds(januszSpawner));
        c.SetDependencies(this);
        Janusze.Add(c);
    }

    public void SpawnSuchar(Transform trans)
    {
        var s = Instantiate(suchar, transform);
        var random = Random.insideUnitCircle;
        s.gameObject.transform.position = trans.position + new Vector3(random.x, 0, random.y);
        Suchary.Add(s);
    }

    public void AddHarnas()
    {
        var c = Instantiate(harnas, transform);
        c.Setup(RandomPointInBounds(harnasSpawner));
        Harnasie.Add(c);
    }

    public void AddChmiel()
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

    public void RemoveJanusz()
    {
        var index = Random.Range(0, Janusze.Count);
        var januszToRemove = Janusze[index];
        Janusze.RemoveAt(index);
        Destroy(januszToRemove.gameObject);
        
    }
    
    public void RemoveHarnas()
    {
        var index = Random.Range(0, Harnasie.Count);
        var harnasToDespawn = Harnasie[index];
        Destroy(harnasToDespawn.gameObject);
        Harnasie.RemoveAt(index);
    }
    
    public void RemoveChmiel()
    {
        var index = Random.Range(0, Chmiele.Count);
        Chmiele.RemoveAt(index);
    }

    public Boolean TakeHarnas()
    {
        if (Harnasie.Count > 0)
        {
            RemoveHarnas();
            return true;
        }
        return false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
            if (hit.collider != null)
            {
                var janusz = hit.collider.gameObject.GetComponent<Janusz>();
                if (janusz != null)
                {
                    janusz.OnClick();
                }
            }
        }

        var toRemove = new List<Suchar>();
        foreach (Suchar s in Suchary)
        {
            if (s.toDestroy)
            {
                Destroy(s.gameObject);
                Coins = Coins + 1;
                toRemove.Add(s);
            }
        }
        foreach (var s in toRemove)
        {
            Suchary.Remove(s);
        }
    }
}
