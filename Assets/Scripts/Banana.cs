using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : MonoBehaviour
{
    public Transform particle;
    private bool pointsavailable = true; 
    
    void Start()
    {
        var emissionModule = particle.GetComponent<ParticleSystem>().emission;
        emissionModule.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Boomerang")) return;
        if (pointsavailable)
        {
            var emissionModule = particle.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = true;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine(StopParticle());
            if (gameObject.CompareTag("SingleBanana"))
            {
                ScoreManager.Score += 1;
            }
            else if (gameObject.CompareTag("MultiBanana"))
            {
                ScoreManager.Score += 3;
            }
            pointsavailable = false;
        }

    }

    IEnumerator StopParticle()
    {
        yield return new WaitForSeconds(0.5f);
        var emissionModule = particle.GetComponent<ParticleSystem>().emission;
        emissionModule.enabled = false;
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
