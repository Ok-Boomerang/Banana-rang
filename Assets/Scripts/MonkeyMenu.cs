using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyMenu : MonoBehaviour
{
    public Sprite sprite1; 
    public Sprite sprite2; 
    public Sprite sprite3;
    public Sprite sprite4;
    public Sprite sprite5; 
    public Sprite sprite6; 
    public Sprite sprite7;
    public Sprite sprite8;
    private Sprite currSprite;
    private SpriteRenderer spriteRenderer;
    private bool swing1;
    private bool swing2;
    private bool done;
    private bool walked;
    void Start ()
    {
        swing1 = true;
        swing2 = true;
        done = false;
        walked = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer.sprite == null)
        {
            spriteRenderer.sprite = sprite1;
        }
        StartCoroutine(Changesprite());
    }
    
    IEnumerator Changesprite() {
        while (true) {
            yield return new WaitForSeconds(0.3f);
            currSprite = spriteRenderer.sprite;
            if (currSprite == sprite1)
            {
                spriteRenderer.sprite = sprite2;
            }
            else if (currSprite == sprite2)
            {
                if(!swing1)
                    transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y, transform.localScale.z);
                if (done)
                {
                    swing1 = true;
                    swing2 = true;
                    done = false;
                    spriteRenderer.sprite = sprite1;
                }
                else if (walked)
                {
                    walked = false;
                    spriteRenderer.sprite = sprite6;
                }
                
                else if (swing1 & swing2 & !done) 
                    spriteRenderer.sprite = sprite3;
                else if (!swing1 & swing2 & !done)
                {
                    swing2 = false;
                    spriteRenderer.sprite = sprite6;
                }
            }
            else if (currSprite == sprite3)
            {
                if (!walked) 
                    spriteRenderer.sprite = sprite4;
                else
                    spriteRenderer.sprite = sprite2;
            }
            else if (currSprite == sprite4)
                spriteRenderer.sprite = sprite5;
            else if (currSprite == sprite5)
            {
                walked = true;
                spriteRenderer.sprite = sprite3;
            }
            else if (currSprite == sprite6)
            {
                if (done | !swing1 & swing2) 
                    spriteRenderer.sprite = sprite2;
                else 
                    spriteRenderer.sprite = sprite7;
            }
            else if (currSprite == sprite7)
                spriteRenderer.sprite = sprite8;
            else if (currSprite == sprite8)
            {
                if (swing1) 
                    swing1 = false; 
                else 
                    done = true; 
                spriteRenderer.sprite = sprite6;
            }
        }
    }
}
