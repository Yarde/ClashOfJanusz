using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] public GameObjectManager gameObjectManager;

    private bool resolve;
    private int nextUpdate;

    // Start is called before the first frame update
    void Start()
    {
        gameObjectManager.Init();
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
}