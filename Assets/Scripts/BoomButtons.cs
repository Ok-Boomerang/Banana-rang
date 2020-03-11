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
        var unibtn = buttons.Find("Unibtn");
        if (unibtn) unibtn.GetComponent<Button>().onClick.AddListener(UniBoom);

        var bibtn = buttons.Find("Bibtn");
        if (bibtn) bibtn.GetComponent<Button>().onClick.AddListener(BiBoom);

        var bladebtn = buttons.Find("Bladebtn");
        if (bladebtn) bladebtn.GetComponent<Button>().onClick.AddListener(BladeBoom);
        
        var bouncybtn = buttons.Find("Bouncybtn");
        if (bouncybtn) bouncybtn.GetComponent<Button>().onClick.AddListener(BouncyBoom);
        
        var quadbtn = buttons.Find("Quadbtn");
        if (quadbtn) quadbtn.GetComponent<Button>().onClick.AddListener(QuadBoom);

        var coolbtn = buttons.Find("Coolbtn");
        if(coolbtn) coolbtn.GetComponent<Button>().onClick.AddListener(CoolBoom);
    }

    private void UniBoom()
    { 
        if (UniManager.uniLeft > 0) redirect("Uni");
    }
    private void BiBoom()
    {
        if (BiManager.biLeft > 0) redirect("Bi");
    }
    private void BladeBoom()
    {
        if (BladeManager.bladeLeft > 0) redirect("Blade");
    }
    private void BouncyBoom()
    {
        if (BounceManager.bounceLeft > 0) redirect("Bouncy");
    }
    private void QuadBoom()
    {
        if (QuadManager.quadLeft > 0) redirect("Quad");
    }

    private void CoolBoom()
    {
        
    }

    private void redirect(string typee)
    {
        Boomerang.newboom = typee;
        switch (typee)
        {
            case("Uni"):
                Boomerang.currboomsleft = UniManager.uniLeft;
                break;
            case("Bi"):
                Boomerang.currboomsleft = BiManager.biLeft;
                break;
            case("Blade"):
                Boomerang.currboomsleft = BladeManager.bladeLeft;
                break;
            case("Bouncy"):
                Boomerang.currboomsleft = BounceManager.bounceLeft;
                break;
            case("Quad"):
                Boomerang.currboomsleft = QuadManager.quadLeft;
                break;
        }
    }
    
}
