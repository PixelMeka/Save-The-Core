using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public TextMeshProUGUI highScoreNum;
    int hScore;
    public GameObject creditsMenu;
    public GameObject mainMenu;

    void Start()
    {
        hScore = PlayerPrefs.GetInt("highScore");
        highScoreNum.text = hScore.ToString();

        creditsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
    void Update()
    {
        hScore = PlayerPrefs.GetInt("highScore");
    }

    public void ResetB()
    {
        PlayerPrefs.SetInt("highScore", 0);
        highScoreNum.text = hScore.ToString();
    }

    public void Play(){
        SceneManager.LoadScene(1);
    }

    public void Credits()
    {
        creditsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Back()
    {
        creditsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
}

