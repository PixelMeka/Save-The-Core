using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject player;
    bool gameEnd = false;
    public bool paused = false;
    public GameObject core;

    public GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        gameEnd = core.GetComponent<Core>().end;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameEnd == false)
        {

            if (Input.GetKeyDown(KeyCode.Escape))
            {

                if (paused)
                {
                    player.GetComponent<MakineHareketi>().enabled = true;
                    Time.timeScale = 1;
                    AudioListener.pause = false;
                    paused = false;

                    pauseMenu.SetActive(false);

                }
                else
                {
                    player.GetComponent<MakineHareketi>().enabled = false;
                    Time.timeScale = 0;
                    AudioListener.pause = true;
                    paused = true;

                    pauseMenu.SetActive(true);
                }



            }

        }
    }

    public void Resume()
    {

        player.GetComponent<MakineHareketi>().enabled = true;
        Time.timeScale = 1;
        AudioListener.pause = false;
        paused = false;

        pauseMenu.SetActive(false);

    }

    public void MainMenu()
    {

        SceneManager.LoadScene(0);

    }
    public void Restart()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
