using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vine : MonoBehaviour
{
    public Transform particle;

    void Start()
    {
        var emissionModule = particle.GetComponent<ParticleSystem>().emission;
        emissionModule.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("here");
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
        Destroy(gameObject);
    }
}
