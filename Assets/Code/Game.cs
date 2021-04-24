using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Code.Events;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Event = Code.Events.Event;


public class Game : MonoBehaviour
{
    [SerializeField] public GameObjectManager gameObjectManager;
    [SerializeField] public EventButton[] eventButtons;
    
    private int nextUpdate;

    // Start is called before the first frame update
    void Start()
    {
        gameObjectManager.Init();
        
        
        // setup event buttons
        eventButtons[0].ev = new WeekOfAlcoholism();
        eventButtons[0].button.onClick.AddListener(() => ApplyEvent(eventButtons[0]));
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextUpdate)
        {
            nextUpdate = Mathf.FloorToInt(Time.time) + 1;
            GameLoop();

            foreach (var b in eventButtons)
            {
                if (b.ev.Cooldown <= 0)
                {
                    b.button.enabled = true;
                    b.buttonText.text = b.text;
                }
                else
                {
                    b.buttonText.text = b.ev.Cooldown.ToString();
                }
            }
            
        }
    }

    void GameLoop()
    {
        Debug.Log("resolve");

        gameObjectManager.Resolve();
    }

    void ApplyEvent(EventButton b)
    {
        b.button.enabled = false;
        b.buttonText.text = b.ev.Cooldown.ToString();
        b.ev.Apply(gameObjectManager);
        gameObjectManager.events.Add(b.ev);
    }
    
    [Serializable]
    public class EventButton
    {
        public string text;
        public Event ev;
        public Button button;
        public TMP_Text buttonText;
    }
}