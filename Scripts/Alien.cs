using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    int score;
    AudioSource audioS;
    public ParticleSystem exp1;
    public ParticleSystem exp2;
    public ParticleSystem exp3;
    public ParticleSystem exp4;
    public ParticleSystem exp5;

    // Start is called before the first frame update
    void Start()
    {
        audioS = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        score = PlayerPrefs.GetInt("curScore");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            audioS.Play();
            exp1.Play();
            exp2.Play();
            exp3.Play();
            exp4.Play();
            exp5.Play();
            PlayerPrefs.SetInt("curScore", 5000);
            Destroy(gameObject, (float)0.7);
        }
    }
}
