using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : MonoBehaviour
{
    public Transform particle;
    private bool single = false;
    private bool multi = false;
    
    void Start()
    {
        var emissionModule = particle.GetComponent<ParticleSystem>().emission;
        emissionModule.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Boomerang")) return;
        var emissionModule = particle.GetComponent<ParticleSystem>().emission;
        emissionModule.enabled = true;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        StartCoroutine(StopParticle());

    }

    IEnumerator StopParticle()
    {
        yield return new WaitForSeconds(0.5f);
        var emissionModule = particle.GetComponent<ParticleSystem>().emission;
        emissionModule.enabled = false;
        yield return new WaitForSeconds(0.5f);
        if (gameObject.CompareTag("SingleBanana"))
        {
            single = true;
        }
        else if (gameObject.CompareTag("MultiBanana"))
        {
            multi = true;
        }
        Destroy(gameObject);
        if (single)
        {
            ScoreManager.Score += 1;
            single = false;
        }
        if (multi)
        {
            ScoreManager.Score += 3;
            multi = false;
        }
    }
}
