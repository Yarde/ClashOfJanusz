﻿using System;
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

        private void Start()
        {
            button.onClick.AddListener(() => gameObject.SetActive(false));
        }

        public void TryAgain()
        {
            SceneManager.LoadScene(2);
        }
    }
}