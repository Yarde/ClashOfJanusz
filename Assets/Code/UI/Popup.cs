using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class Popup : MonoBehaviour
    {
        [SerializeField] public TMP_Text text;
        [SerializeField] public TMP_Text description;
        [SerializeField] public Button button;
        [SerializeField] public TMP_Text buttonText;

        [SerializeField] private Game game;

        private int coins = 20;
        private string t = "19,99 PLN";
        private string d = "Kup więcej w sklepie lub poczekaj 60 minut";

        private void Start()
        {
            button.onClick.AddListener(() =>
            {
                gameObject.SetActive(false);
                game.ResumeGame();
            });
        }

        public void Close()
        {
            buttonText.text = "OK";
            button.onClick.AddListener(() =>
            {
                game.ResumeGame();
                gameObject.SetActive(false);
            });
        }

        public void TryAgain()
        {
            game.Reset();
        }

        public void SetupPayment()
        {
            buttonText.text = t;
            description.text = d;
            button.onClick.AddListener(() => game.gameObjectManager.Coins += coins);
            coins = 0;
            t = "OK";
            d = "Limit kupionych ofert przekroczony";
        }
    }
}