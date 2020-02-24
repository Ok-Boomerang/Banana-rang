using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boomer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 1020 * Time.deltaTime); // adding rotation to the boomerang;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        GameObject GO = other.gameObject;
        switch (GO.tag) // which object has it collided with 
        {
            case "Monkey": // ignore this collision and implement no phyisics
                Physics2D.IgnoreCollision(GO.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
                break;
            case "SingleBanana":
                score.Score += 1;
                break;
            case "MultiBanana":
                score.Score += 3;
                break;
            case "Platform":
                Debug.Log("Platform object");
                break;
            case "Greenery":
                //Debug.Log("Greenery object");
                break;
            default:
                Debug.Log("Default Case, no know tag");
                break;
        }

    }
}
