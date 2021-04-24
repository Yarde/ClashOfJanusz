using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Code.Events;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;
using Event = Code.Events.Event;
using Random = UnityEngine.Random;


public class Game : MonoBehaviour
{
    [SerializeField] public GameObjectManager gameObjectManager;
    [SerializeField] public TMP_Text stats;
    [SerializeField] public TMP_Text coinText;
    [SerializeField] public Popup info;
    [SerializeField] public EventButton[] eventButtons;

    public int coins = 10;
    public int infoTime = 0;

    public int chanceForEvent;
    
    private int nextUpdate;
    
    public List<Event> events = new List<Event>();
    
    void Start()
    {
        gameObjectManager.Init();
        
        // setup event buttons
        eventButtons[0].ev = new OkresGodowy();
        eventButtons[1].ev = new PowodzTysiaclecia();
        eventButtons[2].ev = new FestiwalPiwa();
        eventButtons[3].ev = new Koronawirus();

        for (var i = 0; i < eventButtons.Length; i++)
        {
            var ev = eventButtons[i];
            ev.button.onClick.AddListener(() => ApplyEvent(ev));
            ev.priceText.text = ev.price.ToString();
            ev.buttonText.text = ev.ev.name;
        }

        events.Add(new NowaFabrykaHarnasia());
        events.Add(new PincsetPlus());
        events.Add(new PromocjaWBiedronce());
        events.Add(new RadioaktywnyDeszcz());
        events.Add(new WywroconyTir());
        events.Add(new TydzienAlkoholizmu());
        events.Add(new TydzienTrzezwosci());
    }
    
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

            if (chanceForEvent > Random.Range(10, 100))
            {
                chanceForEvent = 0;
                var active = events.Where(x => x.Cooldown <= 0).ToList();
                
                int index = Random.Range(0, active.Count);

                var ev = active[index];
                ApplyEvent(ev);
            }
            else
            {
                chanceForEvent++;
            }
            
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
                    b.buttonText.text = b.ev.name;
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
            info.text.text = "Za mało cebuli!";
            info.description.text = "Kup więcej cebuli w sklepie lub poczekaj 60 minut";
            infoTime = 3;
            return;
        }
        
        coins -= b.price;
        b.button.enabled = false;
        b.buttonText.text = b.ev.Cooldown.ToString();
        ApplyEvent(b.ev);
    }

    void ApplyEvent(Event ev)
    {
        ev.Apply(gameObjectManager);
        gameObjectManager.events.Add(ev);
        
        info.gameObject.SetActive(true);
        info.text.text = ev.name;
        info.description.text = ev.description;
        infoTime = 5;
    }
    
    [Serializable]
    public class EventButton
    {
        public int price;
        public TMP_Text priceText;
        public Event ev;
        public Button button;
        public TMP_Text buttonText;
    }
}