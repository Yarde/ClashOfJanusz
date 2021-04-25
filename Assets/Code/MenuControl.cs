using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour
{
    [SerializeField] private Image tutorial;
    
    public void NewGame()
    {
        if (tutorial.gameObject.active)
        {
            SceneManager.LoadScene("Game");
        }
        tutorial.gameObject.SetActive(true);
    }
}
