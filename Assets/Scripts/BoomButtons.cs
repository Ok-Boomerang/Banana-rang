using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoomButtons : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        var buttons = transform.Find("BoomerangButtons");
        var unibtn = buttons.Find("Unibtn").GetComponent<Button>();
        unibtn.onClick.AddListener(UniBoom);

        var bibtn = buttons.Find("Bibtn").GetComponent<Button>();
        bibtn.onClick.AddListener(BiBoom);

        var bladebtn = buttons.Find("Bladebtn").GetComponent<Button>();
        bladebtn.onClick.AddListener(BladeBoom);
        
        var bouncybtn = buttons.Find("Bouncybtn").GetComponent<Button>();
        bouncybtn.onClick.AddListener(BouncyBoom);
        
        var quadbtn = buttons.Find("Quadbtn").GetComponent<Button>();
        quadbtn.onClick.AddListener(QuadBoom);
    }

    private void UniBoom()
    { 
        redirect("Uni");
    }
    private void BiBoom()
    { 
        redirect("Bi");
    }
    private void BladeBoom()
    { 
        redirect("Blade");
    }
    private void BouncyBoom()
    { 
        redirect("Bouncy");
    }
    private void QuadBoom()
    { 
        redirect("Quad");
    }

    private void redirect(string typee)
    {
        Boomerang.newboom = typee;
    }
    
}
