using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollider : MonoBehaviour
{
    public ParticleSystem dirtHit;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 8);

        audioSource = GetComponent<AudioSource>();
        ParticleSystem dirtHit = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            dirtHit.Play();
            audioSource.Play();
        }
    }
}
