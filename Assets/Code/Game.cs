using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Code.Events;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;
using Event = Code.Events.Event;


public class Game : MonoBehaviour
{
    [SerializeField] public GameObjectManager gameObjectManager;
    [SerializeField] public TMP_Text stats;
    [SerializeField] public TMP_Text coinText;
    [SerializeField] public Popup info;
    [SerializeField] public EventButton[] eventButtons;

    public int coins = 10;
    public int infoTime = 0;
    
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

            stats.text = $"Janusze: {gameObjectManager.Carnivores.Count} " +
                         $"Harnasie: {gameObjectManager.Herbivores.Count} " +
                         $"Chmiel: {gameObjectManager.Plants.Count} " +
                         $"Woda: {gameObjectManager.Waters.Count} ";

            coinText.text = $"Gold: {coins}";

            if (infoTime > 0)
            {
                infoTime--;
                if (infoTime <= 0)
                {
                    info.gameObject.SetActive(false);
                }
            }

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
        if (coins < b.price)
        {
            info.gameObject.SetActive(true);
            info.text.text = "Za mało cebuli \n kup więcej cebuli w sklepie lub poczekaj 60 minut";
            infoTime = 3;
        }
        
        coins -= b.price;
        b.button.enabled = false;
        b.buttonText.text = b.ev.Cooldown.ToString();
        b.ev.Apply(gameObjectManager);
        gameObjectManager.events.Add(b.ev);
    }
    
    [Serializable]
    public class EventButton
    {
        public string text;
        public int price;
        public TMP_Text priceText;
        public Event ev;
        public Button button;
        public TMP_Text buttonText;
    }
}