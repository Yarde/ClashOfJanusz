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
    [SerializeField] public TMP_Text timer;
    [SerializeField] public Popup popup;
    [SerializeField] public EventButton[] eventButtons;

    public int coins = 20;
    public int infoTime = 0;

    public int chanceForEvent;
    
    private int nextUpdate = 0;
    
    public List<Event> events = new List<Event>();

    private float timeout = 240;
    
    public float timeStart;
    public float inGameTime = 240;
    
    void Start()
    {
        coins = 10;

        eventButtons[0].ev = new BoostSucharow();
        eventButtons[1].ev = new NowyChmiel();
        eventButtons[2].ev = new NowyJanusz();

        for (var i = 0; i < eventButtons.Length; i++)
        {
            var ev = eventButtons[i];
            ev.button.onClick.AddListener(() => ApplyEvent(ev));
            ev.priceText.text = ev.price.ToString();
            ev.buttonText.text = "";
        }

        events.Add(new NowaFabrykaHarnasia());
        events.Add(new PincsetPlus());
        events.Add(new PromocjaWBiedronce());
        events.Add(new RadioaktywnyDeszcz());
        events.Add(new WywroconyTir());
        events.Add(new TydzienAlkoholizmu());
        events.Add(new TydzienTrzezwosci());
        events.Add(new PogromJanuszy());

        timeStart = Time.realtimeSinceStartup;
    }
    
    void Update()
    {
        gameObjectManager.Init();
        inGameTime -= Time.deltaTime;
        var failure = inGameTime < 0 && Time.timeScale > 0;
        inGameTime = Mathf.Max(inGameTime, 0);
        if (Time.time >= nextUpdate)
        {
            nextUpdate = Mathf.FloorToInt(Time.time) + 1;
            GameLoop();
            
            timer.text = $"Czas: {GetTime(inGameTime)}";

            if (gameObjectManager.Janusze.Count >= 10)
            {
                popup.gameObject.SetActive(true);
                popup.text.text = "Wygrałeś!";
                popup.description.text = $"Zdobyłeś {gameObjectManager.Points + gameObjectManager.Coins*3} punktów w {GetTime(timeout - inGameTime)}";
                popup.buttonText.text = "Hura!";
                popup.button.onClick.AddListener(popup.TryAgain);
                nextUpdate = Mathf.FloorToInt(Time.time) + 10000;
            }

            if (failure)
            {
                popup.gameObject.SetActive(true);
                popup.text.text = "Przegrałeś :(";
                popup.description.text = $"Zdobyłeś {gameObjectManager.Points + gameObjectManager.Coins*3} punktów w {GetTime(timeout)}";
                popup.buttonText.text = "Nie wytrzymię...";
            }
        }
        
        foreach (var b in eventButtons)
        {
            if (b.ev.Cooldown <= 0)
            {
                b.button.enabled = true;
                b.buttonText.text = "";
            }
            else
            {
                b.buttonText.text = b.ev.Cooldown.ToString();
            }
        }
        
        stats.text = $"Janusze: {gameObjectManager.Janusze.Count} " +
                     $"Harnasie: {gameObjectManager.Harnasie.Count} " +
                     $"Chmiel: {gameObjectManager.Chmiele.Count} ";

        coinText.text = $"{gameObjectManager.Coins}";
    }
    
    void PauseGame ()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame ()
    {
        Time.timeScale = 1;
    }

    string GetTime(float time)
    {
        var minutes = (int) (time / 60);
        var seconds = (int) (time % 60);

        if (seconds < 10)
        {
            return $"0{minutes}:0{seconds}";
        }
        return $"0{minutes}:{seconds}";
    }

    void GameLoop()
    {
        if (gameObjectManager.Resolve())
        {
            return;
        }


        if (chanceForEvent > Random.Range(20, 100))
        {
            chanceForEvent = 0;
            var active = events.Where(x => x.Cooldown <= 0).ToList();
                
            int index = Random.Range(0, active.Count);

            var ev = active[index];
            ApplyEvent(ev, true);
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
                ResumeGame();
                popup.gameObject.SetActive(false);
            }
        }
    }

    void ApplyEvent(EventButton b)
    {
        if (gameObjectManager.Coins < b.price)
        {
            PauseGame();
            popup.gameObject.SetActive(true);
            popup.text.text = "Za mało kapsli!";
            popup.description.text = "Kup więcej w sklepie lub poczekaj 60 minut";
            popup.SetupPayment();
            infoTime = 10;
            return;
        }
        
        gameObjectManager.Coins -= b.price;
        b.button.enabled = false;
        ApplyEvent(b.ev, false);
        if (b.ev.Cooldown > 0)
        {
            b.buttonText.text = b.ev.Cooldown.ToString();
        }
    }

    void ApplyEvent(Event ev, bool showPopup)
    {
        ev.Apply(gameObjectManager);
        gameObjectManager.events.Add(ev);

        if (showPopup)
        {
            popup.Close();
            PauseGame();
            popup.gameObject.SetActive(true);
            popup.text.text = ev.name;
            popup.description.text = ev.description;
            infoTime = 10;
        }
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

    public void Reset()
    {
        gameObjectManager.Reset();
        Start();
        popup.Close();
    }
}