using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Code.Events;
using UnityEngine;
using UnityEngine.UI;


public class Game : MonoBehaviour
{
    [SerializeField] public GameObjectManager gameObjectManager;
    
    [SerializeField] public Button ev1;
    
    
    private int nextUpdate;
    
    

    // Start is called before the first frame update
    void Start()
    {
        gameObjectManager.Init();
        
        ev1.onClick.AddListener(ApplyEvent);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextUpdate)
        {
            nextUpdate = Mathf.FloorToInt(Time.time) + 1;
            GameLoop();
        }
    }

    void GameLoop()
    {
        Debug.Log("resolve");

        gameObjectManager.Resolve();
    }

    void ApplyEvent()
    {
        var ev = new WeekOfAlcoholism();
        ev.Apply(gameObjectManager);
        gameObjectManager.events.Add(ev);
    }
}