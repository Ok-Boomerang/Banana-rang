using System;
using UnityEngine;
using UnityEngine.EventSystems;


public class Boomerang : MonoBehaviour
{
    private static Rigidbody2D _boom_rb;
    public static bool _thrown; //has the boomerang been thrown yet?
    public static float _maxdistance = 40f; // farthers distance it should travel
    public Transform _home; // where the boomerang returns too
    public Transform arrow;
    public static Transform globalArrow;
    public Transform maxArrow;
    public static bool _forward = true; // is it in a forward or backward motion
    private Vector3 _distancereleased; // the distance it has traveled so far
    private Vector2 _lookdirection;
    private float _lookAngle;
    private float _clickStart;
    private float _power;
    public static float _distancetogo;
    private bool _clicked;
    private static bool gameover = false;
    private Vector3 scale;
    private Vector3 arrowScale;
    private Vector3 maxScale;
    // Switching between boomerang vars
    public GameObject currboom;
    public static string newboom;
    public static int currboomsleft;
    public GameObject Uni;
    public GameObject Bi;
    public GameObject Blade;
    public GameObject Bouncy;
    public GameObject Quad;
    public int Uninum;
    public int Binum;
    public int Bladenum;
    public int Bouncenum;
    public int Quadnum;
    public static bool restarted = false;
   // end of vars 
   
   //private DebugHUD _hud;
   //public Material DebugMaterial;
   private void Awake()
    {
        globalArrow = arrow;
        switch(currboom.name)
        {
            case("Uni"):
                currboomsleft = Uninum;
                break;
            case("Bi"):
                currboomsleft = Binum;
                break;
            case("Blade"):
                currboomsleft = Bladenum;
                break;
            case("Bouncy"):
                currboomsleft = Bouncenum;
                break;
            case("Quad"):
                currboomsleft = Quadnum;
                break;
        }
    }
   private void Start()
    {
        _boom_rb = gameObject.GetComponent<Rigidbody2D>();
        _home = GameObject.Find("MonkeyHand").transform;
        scale = transform.localScale;
        arrowScale = new Vector3(.17f, .2f, 0f);
        maxScale = maxArrow.localScale;
        // _hud = new DebugHUD(DebugMaterial);
    }
    void Update()
    {
        if (gameover & !_thrown) return;
            CurrentBoom();
        if (!_thrown & currboomsleft > 0)
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                arrow.localScale = new Vector3(0f, 0f, 0f);
                return;
            }
            _lookdirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            _lookAngle = Mathf.Atan2(_lookdirection.y, _lookdirection.x) * Mathf.Rad2Deg;
            maxArrow.rotation = Quaternion.LookRotation(Vector3.forward, _lookdirection);
            if (Input.GetMouseButtonDown(0))
            {
                _clicked = true;
                _clickStart = Time.time;
                GameObject.Find("Monkey").GetComponent<monkey>()._mousedown = true;
            }

            if (Input.GetMouseButton(0))
            {
                var powerholder = 2f * (Time.time - _clickStart);
                if (Math.Truncate(powerholder) % 2 == 0)
                {
                    _power = (float) (powerholder - Math.Truncate(powerholder));
                }
                else
                {
                    _power = 1 - (float) (powerholder - Math.Truncate(powerholder));
                }
                if (_clicked)
                {
                    arrow.rotation = Quaternion.LookRotation(Vector3.forward, _lookdirection);
                    Vector3 aScale = arrow.localScale;
                    aScale.y = _power * arrowScale.y * 1.5f;
                    aScale.x = arrowScale.x;
                    arrow.localScale = aScale;
                }
            }

            if (!(Input.GetMouseButtonUp(0) & _clicked)) return;
            _clicked = false;
            _distancereleased = transform.position;
            _thrown = true;
            Winning.boomerangsLeft -= 1;
            GameObject.Find("Monkey").GetComponent<monkey>()._mousedown = false;
            if (currboom == Uni)
            {
                UniManager.uniLeft -= 1;
                currboomsleft -= 1;
                ScoreManager.Thrown += 1;
                Uniboom.throwboomerang( _lookAngle, _power);
            }
            else if (currboom == Bi)
            {
                BiManager.biLeft -= 1;
                currboomsleft -= 1;
                ScoreManager.Thrown += 1;
                BIboom.throwboomerang( _lookAngle, _power);
            }
            else if (currboom == Blade)
            {
                BladeManager.bladeLeft -= 1;
                currboomsleft -= 1;
                ScoreManager.Thrown += 1;
                Bladeboom.throwboomerang( _lookAngle, _power);
            }
            else if (currboom == Bouncy)
            {
                BounceManager.bounceLeft -= 1;
                currboomsleft -= 1;
                ScoreManager.Thrown += 1;
                Bouncyboom.throwboomerang( _lookAngle, _power);
            }
            else if (currboom == Quad)
            {
                QuadManager.quadLeft -= 1;
                currboomsleft -= 1;
                ScoreManager.Thrown += 1;
                Quadboom.throwboomerang( _lookAngle, _power);
            }
        }
        else if (_thrown)
        {
            if (currboom == Blade || currboom == Quad || currboom == Bouncy)
            {
                if (currboom == Blade) Bladeboom.gravity();
                if (currboom == Quad) Quadboom.gravity();
                if (Mathf.Abs(
                        (Camera.main.transform.position.y - (Camera.main.orthographicSize)) - transform.position.y) <=
                    0.5f || Mathf.Abs(
                        (Camera.main.transform.position.x + (Camera.main.aspect * Camera.main.orthographicSize)) - transform.position.x) <=
                    0.5f || Mathf.Abs(
                        (Camera.main.transform.position.x - (Camera.main.aspect * Camera.main.orthographicSize)) - transform.position.x) <=
                    0.5f)
                {
                    _thrown = false;
                    _forward = true;
                    _boom_rb.velocity = new Vector3(0f, 0f, 0f);
                    arrow.localScale = new Vector3(0f, 0f, 0f);

                }
            }
            if(currboom!= Bouncy) transform.Rotate(0, 0, 1100 * Time.deltaTime);
            else transform.Rotate(0, 0, Bouncyboom.bounceDir * 600 * Time.deltaTime);
            if (_forward & Vector3.Distance(_distancereleased, transform.position) >= _distancetogo)
            {
                if (currboom == Uni)
                {
                    Uniboom.returnboom();
                    _forward = false;
                }
                else if (currboom == Bi)
                {
                    BIboom.returnboom();
                    _forward = false;
                }
            }
            else if (!_forward & Vector3.Distance(_distancereleased, transform.position) <= 1f || 
                     !_forward & Mathf.Abs((Camera.main.transform.position.x - (Camera.main.aspect * Camera.main.orthographicSize)) - transform.position.x) <= 0.5f)
            {
                _thrown = false;
                _forward = true;
                _boom_rb.velocity = new Vector3(0f,0f,0f);
                arrow.localScale = new Vector3(0f,0f,0f);
            }
        }
    }
        

    private void LateUpdate()
    {
        if (!_thrown) 
        {
            SetInHand(); 
        }
    }

    private void SetInHand()
    {
        transform.position = _home.position;
        transform.rotation = _home.rotation;
        transform.localScale = new Vector3(_home.localScale.x * scale.x, scale.y, scale.z);
        _forward = true;
    }

   // Used to switch boomerang
    private void CurrentBoom()
    {
        if(!_thrown & newboom != null & currboom.name != newboom) 
        {
            currboom.SetActive(false);
            switch (newboom)
            {
                case "Uni":
                    currboom = Uni;
                    break;
                case "Bi":
                    currboom = Bi;
                    break;
                case "Blade":
                    currboom = Blade;
                    break;
                case "Bouncy":
                    currboom = Bouncy;
                    break;
                case "Quad":
                    currboom = Quad;
                    break;
            }
            currboom.SetActive(true);
        }
        newboom = null;
    }

    
    /*private void OnCollisionEnter2D(Collision2D other)
    {
        GameObject GO = other.gameObject;
        switch (GO.tag) // which object has it collided with 
        {
            case "Platform":
                Debug.Log("Platform object");
                _boom_rb.velocity = new Vector3(0f, 0f, 0f);
                _thrown = false;
                break;
            case "Greenery":
                //Debug.Log("Greenery object");
                break;
        }
    }*/

  public static void GameOver()
  {
      gameover = true;
  }

  public static void Restart()
  {
      gameover = false;
      ScoreManager.Score = 0;
      ScoreManager.Thrown = 0;
      Winning.boomerangsLeft = Winning._startBooms;
      _boom_rb.velocity = new Vector3(0f,0f,0f);
      _thrown = false;
      _forward = true;
       restarted = true;

  }
}
