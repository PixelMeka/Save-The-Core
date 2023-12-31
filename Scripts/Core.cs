using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Core : MonoBehaviour
{
    public GameObject highScoreText;
    public GameObject scoreText;
    public GameObject scoreTextNum;

    public GameObject player;
    public GameObject gameOverPanel;

    AudioSource audioSource;
    public GameObject warning;

    public ParticleSystem overheat;
    public ParticleSystem critial;
    public int counter = 0;
    public float timer = 3;
    public double timerEnd = 0.8;
    public bool end = false;
    int spawnNumber;
    public GameObject ProSeed;
    public GameObject point0;
    public GameObject point1;
    public GameObject point2;
    public GameObject point3;
    public GameObject point4;
    public GameObject point5;
    public GameObject point6;
    public GameObject point7;

    public GameObject explosion;

    bool audioC = false;
    bool explode = false;
    bool realEnd = false;

    bool spawned = false;
    public float spawnTimer = 7;

    int score;
    int oldScore;
    public float scoreRatio;

    // Start is called before the first frame update
    void Start()
    {
        oldScore = PlayerPrefs.GetInt("highScore");
        scoreText.SetActive(true);
        scoreTextNum.SetActive(true);
        gameOverPanel.SetActive(false);

        player.GetComponent<MakineHareketi>().enabled = true;
        ParticleSystem overheat = GetComponent<ParticleSystem>();
        warning.SetActive(false);
        audioSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void Update()
    {
        score = PlayerPrefs.GetInt("curScore");

        float scoreRatio = (float)score / 40;

        if (scoreRatio >= 7)
        {
            scoreRatio = 6;
        }
       

        if (spawned == false)
        {
            spawnNumber = Random.Range(1, 9);
            if (spawnNumber == 1)
            {
                Instantiate(ProSeed, point0.transform.position, point0.transform.localRotation);
                spawned = true;
            }
            if (spawnNumber == 2)
            {
                Instantiate(ProSeed, point1.transform.position, point1.transform.localRotation);
                spawned = true;
            }
            if (spawnNumber == 3)
            {
                Instantiate(ProSeed, point2.transform.position, point2.transform.localRotation);
                spawned = true;
            }
            if (spawnNumber == 4)
            {
                Instantiate(ProSeed, point3.transform.position, point3.transform.localRotation);
                spawned = true;
            }
            if (spawnNumber == 5)
            {
                Instantiate(ProSeed, point4.transform.position, point4.transform.localRotation);
                spawned = true;
            }

            if (spawnNumber == 6)
            {
                Instantiate(ProSeed, point5.transform.position, point5.transform.localRotation);
                spawned = true;
            }
            if (spawnNumber == 7)
            {
                Instantiate(ProSeed, point6.transform.position, point6.transform.localRotation);
                spawned = true;
            }
            if (spawnNumber == 8)
            {
                Instantiate(ProSeed, point7.transform.position, point7.transform.localRotation);
                spawned = true;
            }


        }
        

        if(spawned == true)
        {
            if (spawnTimer > 0)
            {
                spawnTimer -= Time.deltaTime;
            }
            if (spawnTimer <= 0)
            {
                spawnTimer = 7 - (float)scoreRatio;
                spawned = false;
            }
        }




        if (counter >= 2)
        {
            overheat.Play();
            critial.Stop();
        }
        if(counter < 2)
        {
            overheat.Stop();
            critial.Stop();
        }

        if(counter >= 3)
        {
            if(audioC == false)
            {
                warning.SetActive(true);
                audioSource.Play();
                audioC = true;
            }
            critial.Play();
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            if (timer <= 0)
            {
                end = true;
            }
        }
        if(counter < 3)
        {
            warning.SetActive(false);
            audioSource.Stop();
            audioC = false;
            timer = 3;
        }

        if(end == true)
        {
            warning.SetActive(false);

            if(explode == false)
            {
                Instantiate(explosion, this.transform.position, Quaternion.identity);
                explode = true;
            }
            

            if (timerEnd > 0)
            {
                timerEnd -= Time.deltaTime;
            }

            if (timerEnd <= 0)
            {
                realEnd = true;
            }

            if (realEnd)
            {
                audioSource.Stop();
                gameOverPanel.SetActive(true);
                scoreText.SetActive(false);
                scoreTextNum.SetActive(false);
                Time.timeScale = 0;
                AudioListener.pause = true;
                player.GetComponent<MakineHareketi>().enabled = false;

                if(score > oldScore)
                {
                    PlayerPrefs.SetInt("highScore", score);
                    highScoreText.SetActive(true);
                }
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            counter += 1;
        }
    }
}
