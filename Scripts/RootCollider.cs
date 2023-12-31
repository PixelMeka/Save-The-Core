using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootCollider : MonoBehaviour
{

    public ParticleSystem power;
    public ParticleSystem sliced;
    public double timer = 0.3;
    public GameObject seed;
    AudioSource audioSource;
    bool die = false;
    bool poweringUp = false;
    bool decrementCounter = false;

    int score;

    // Start is called before the first frame update
    void Start()
    {
        ParticleSystem power = GetComponent<ParticleSystem>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        score = PlayerPrefs.GetInt("curScore");

        if(die == true)
        {
            if(poweringUp == true && decrementCounter == false)
            {
                score += 10;
                PlayerPrefs.SetInt("curScore", score);
                GameObject.Find("Core").GetComponent<Core>().counter -= 1;
                decrementCounter = true;
            }

            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            if (timer <= 0)
            {
                Destroy(seed);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Bullet")
        {
            sliced.Play();
            die = true;
            score += 10;
            PlayerPrefs.SetInt("curScore", score);
            
        }

        if (other.gameObject.tag == "Core")
        {
            power.Play();
            audioSource.Play();
            poweringUp = true;
        }
    }
}
