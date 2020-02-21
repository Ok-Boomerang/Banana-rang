using UnityEngine;
using UnityEngine.EventSystems;


public class Boomerang : MonoBehaviour
{
    private static Rigidbody2D _boom_rb;
    public static bool _thrown; //has the boomerang been thrown yet?
    private float _maxdistance = 40f; // farthers distance it should travel
    public Transform _home; // where the boomerang returns too
    private bool _forward = true; // is it in a forward or backward motion
    private Vector3 _distancereleased; // the distance it has traveled so far
    private Vector2 _lookdirection;
    private float _lookAngle;
    private float _clickStart;
    private float _power;
    private float _distancetogo;
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
            _distancetogo =
                (_power * _maxdistance > _maxdistance ? _maxdistance : _power * _maxdistance);
            _thrown = true;
            BoomerangManager.boomerangsLeft -= 1;
            _distancereleased = transform.position;
            transform.rotation = Quaternion.Euler(0f, 0f, _lookAngle - 90f);
            _boom_rb.velocity = transform.up * 20f;
            GameObject.Find("Monkey").GetComponent<monkey>()._mousedown = false;
        }
        else if (_thrown)
        {
            transform.Rotate(0, 0, 1100 * Time.deltaTime);
            if (_forward & Vector3.Distance(_distancereleased, transform.position) >= _distancetogo)
            {
                _forward = false;
                _boom_rb.velocity = _boom_rb.velocity * -1;
            }
            else if (!_forward & Vector3.Distance(_distancereleased, transform.position) <= 1f)
            {
                _thrown = false;
                _forward = true;
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
  /*
       internal void OnGUI()
    {
        var val = new Vector3(_lookdirection.x, _lookdirection.y, 0).normalized * 50f; // 50 pixel long vector in the direction of the mouse relative to the monkey
        _hud.DrawMagnitude(_power);
        //_hud.DrawMagnitude(_power);
    }
  /// <summary>
      /// Helper class to draw lines, etc. on the screen
      /// </summary>
      private class DebugHUD
      {
          private static readonly Vector2 HUDCorner = new Vector2(20f, 200f);
          private static readonly Vector3 ArrowStart = HUDCorner + new Vector2(50f, 50f);
          public Transform _home;
          private readonly Material _mat;
  
          public DebugHUD(Material mat)
          {
              _mat = mat;
          }
  
          public void DrawArrow(Vector3 value, float _power, Transform mh)
          {
  
              GL.PushMatrix();
              _mat.SetPass(0);
              GL.LoadPixelMatrix();
  
              GL.Begin(GL.LINES);
              GL.Color(Color.red);
  
              Vector3 my_arrowstart = Vector3.Normalize(new Vector3(0, 0, 0));
              ;
              Vector3 value_vertex = Vector3.Normalize(value);
  
  
              GL.Vertex(new Vector3(70f + (my_arrowstart.x * _power * 50f), 70f + (my_arrowstart.y * _power * 50f), 0f));
  
              Vector3 vel = new Vector3(70f + (value_vertex.x * _power * 50f), 70f + (value_vertex.y * _power * 50f), 0f);
  
              GL.Vertex(vel);
              GL.End();
  
  
              GL.Begin(GL.TRIANGLES);
              GL.Color(Color.red);
              Vector3 pnt = Vector3.Normalize(new Vector3(-(my_arrowstart.y - value_vertex.y),
                  my_arrowstart.x - value_vertex.x, 0f));
              Vector3 perp_pnt = Vector3.Normalize(new Vector3((my_arrowstart.x - value_vertex.x),
                  my_arrowstart.y - value_vertex.y, 0f));
              GL.Vertex(new Vector3(vel.x + (pnt.x * -5), vel.y + (pnt.y * -5), 0f));
              GL.Vertex(new Vector3(vel.x + (pnt.x * 5), vel.y + (pnt.y * 5), 0f));
              GL.Vertex(new Vector3(vel.x + (perp_pnt.x * -10), vel.y + (perp_pnt.y * -10), 0f));
              GL.End();
              GL.PopMatrix();
          }
          public void DrawMagnitude(float magnitude)
          {
              _mat.SetPass(0);
              GL.LoadPixelMatrix();
              GL.Begin(GL.QUADS);
              GL.Color(Color.red);
              GL.Vertex(new Vector3(25f, (10f + magnitude * 50f), 0f));
              GL.Vertex(new Vector3(0f, (10f + magnitude * 50f), 0f));
              GL.Vertex(new Vector3(0f, 0f, 0f));
              GL.Vertex(new Vector3(25, 0f, 0f));
              GL.End();
  
          }
      }*/
}
