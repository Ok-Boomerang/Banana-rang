using UnityEngine;
using UnityEngine.EventSystems;


public class Boomerang : MonoBehaviour
{
    private static Rigidbody2D _boom_rb;
    public static bool _thrown; //has the boomerang been thrown yet?
    public static float _maxdistance = 40f; // farthers distance it should travel
    public Transform _home; // where the boomerang returns too
    private bool _forward = true; // is it in a forward or backward motion
    private Vector3 _distancereleased; // the distance it has traveled so far
    private Vector2 _lookdirection;
    private float _lookAngle;
    private float _clickStart;
    private float _power;
    public static float _distancetogo;
    private bool _clicked;
    private static bool gameover = false;

    private Vector3 scale;
    // Switching between boomerang vars
    public GameObject currboom;
    public static string newboom;
    public GameObject Uni;
    public GameObject Bi;
    public GameObject Blade;
    public GameObject Bouncy;
    public GameObject Quad;
   // end of vars 
   
   //private DebugHUD _hud;
   //public Material DebugMaterial;
    private void Start()
    {
        _boom_rb = gameObject.GetComponent<Rigidbody2D>();
        _home = GameObject.Find("MonkeyHand").transform;
        scale = transform.localScale;
        // _hud = new DebugHUD(DebugMaterial);
    }
    void Update()
    {
        if (gameover & !_thrown) return;
            CurrentBoom();
        if (!_thrown)
        {
            if (EventSystem.current.IsPointerOverGameObject()) return;
            _lookdirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            _lookAngle = Mathf.Atan2(_lookdirection.y, _lookdirection.x) * Mathf.Rad2Deg;
            if (Input.GetMouseButtonDown(0))
            {
                _clicked = true;
                _clickStart = Time.time;
                GameObject.Find("Monkey").GetComponent<monkey>()._mousedown = true;
            }

            if (Input.GetMouseButton(0))
            {
                _power = 2f * (Time.time - _clickStart);
            }

            if (!(Input.GetMouseButtonUp(0) & _clicked)) return;
            _clicked = false;
            _distancereleased = transform.position;
            _thrown = true;
            BoomerangManager.boomerangsLeft -= 1;
            GameObject.Find("Monkey").GetComponent<monkey>()._mousedown = false;
            if (currboom == Uni)
            {
                Uniboom.throwboomerang( _lookAngle, _power);
            }
            else if (currboom == Bi)
            {
                Debug.Log("Fix Biboom script");
                BIboom.throwboomerang( _lookAngle, _power);
            }
            else if (currboom == Blade)
            {
                Debug.Log("Fix Bladeboom script");
                Bladeboom.throwboomerang( _lookAngle, _power);
            }
            else if (currboom == Bouncy)
            {
                Debug.Log("Fix Bouncyboom script");
                Bouncyboom.throwboomerang( _lookAngle, _power);
            }
            else if (currboom == Quad)
            {
                Debug.Log("Fix Quadboom script");
                Quadboom.throwboomerang( _lookAngle, _power);
            }
        }
        else if (_thrown)
        {
            transform.Rotate(0, 0, 1100 * Time.deltaTime);
            if (_forward & Vector3.Distance(_distancereleased, transform.position) >= _distancetogo)
            {
                _forward = false;
                if (currboom == Uni)
                {
                    Uniboom.returnboom();
                }
                else if (currboom == Bi)
                {
                    BIboom.returnboom();
                }
                else if (currboom == Blade)
                {

                    Bladeboom.returnboom();
                }
                else if (currboom == Bouncy)
                {
                    Bouncyboom.returnboom();
                }
                else if (currboom == Quad)
                {
                    Quadboom.returnboom();
                }
            }
            else if (!_forward & Vector3.Distance(_distancereleased, transform.position) <= 1f)
            {
                _thrown = false;
                _forward = true;
                _boom_rb.velocity = new Vector3(0f,0f,0f);
            }
        }
    }
        

    private void LateUpdate()
    {
        if (!_thrown) 
        { SetInHand(); }
    }

    private void SetInHand()
    {
        transform.position = _home.position;
        transform.rotation = _home.rotation;
        transform.localScale = new Vector3(_home.localScale.x * scale.x, scale.y, scale.z);
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

    
  /*  private void OnCollisionEnter2D(Collision2D other)
    {
        GameObject GO = other.gameObject;
        switch (GO.tag) // which object has it collided with 
        {
            case "Platform":
                Debug.Log("Platform object");
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
      BoomerangManager.boomerangsLeft = 5;
      _boom_rb.velocity = new Vector3(0f,0f,0f);
      _thrown = false;
  }
}
