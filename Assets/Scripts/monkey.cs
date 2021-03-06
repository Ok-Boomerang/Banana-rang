﻿using System;
using System.Collections;
using UnityEngine;

public class monkey : MonoBehaviour
{
    //Monkey components 
    private Rigidbody2D monkeyRB;
    private SpriteRenderer spriteRenderer;
    // end of explicit monkey components 
    
    // Monkey sprites 
    public Sprite standingsideways;
    public Sprite jumpstance;
    public Sprite monkeythrow1; 
    public Sprite monkeythrow2;
    public Sprite walk1;
    public Sprite walk2;
    public Sprite walk3;
    public Sprite walk4;
    public Sprite currSprite;
    //end of monkey sprites 
    
    // Vars for Sprites 
    private float _spriteratechagne = 0.15f; // how fast the sprites change
    private Vector3 _scale; // used which way the sprite is facing;
    private Vector3 _childscale;
    public bool _mousedown; // used to change the throwing sprite
    // end of sprite vars 
    
    // movement vars 
    private float _jumpspeed = 450f; // used to set how high the monkey can jump on a certain surface.
    private float _speed = 4f; // how fast the monkey moves left and right
    private bool _up;
    private bool _left;
    private bool _right;
    private bool _jumped;
    // end of movement vars
    
    // vars for restricting the monkeys location 
    public Camera monkeybounds; //the camera that helps represent the boundaries for the monkey 
    private float _objectWidth; // center of the objects width
    private float _objectHeight; // center of the objects height 
    private Vector2 _screenposition; //position of the camera 
    private float _halfHeight; //the center of the camera's height 
    private float _halfWidth; // the center of the camera's width
    // end of boundary vars 
    
    void Start ()
    {
        //storing useful components
        spriteRenderer = GetComponent<SpriteRenderer>();
        _scale = transform.localScale;
        _childscale = transform.GetChild(0).localScale;
        monkeyRB = gameObject.GetComponent<Rigidbody2D>();
        
        // storing the boundaries that the monkey can walk around in
        _halfHeight = monkeybounds.orthographicSize;
        _halfWidth = monkeybounds.aspect * _halfHeight;
        _screenposition = monkeybounds.transform.position;
        _objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x; //extents = size of width / 2
        _objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y; //extents = size of height / 2
        
        // change sprites as necessary 
        StartCoroutine(SetSprite());
    }
    void Update()
    {
        //get key inputs for the monkey's movement
        _up = Input.GetKey(KeyCode.Space);
        _right = Input.GetKey(KeyCode.D);
        _left = Input.GetKey(KeyCode.A);

        if (_up & !_jumped & monkeyRB.velocity.y == 0f)
        {
            //make the monkey jump up, gets one jump at a time
            _jumped = true;
            monkeyRB.AddForce(Vector2.up * _jumpspeed, ForceMode2D.Force);
            spriteRenderer.sprite = jumpstance;
        }
        if (_right != _left)
        {
            if (_right)
            {
                // face in the direction the monkey is walking
                transform.localScale = _scale;
                transform.GetChild(0).localScale = _childscale;
                // move to the right 
                transform.position += Time.deltaTime * _speed * Vector3.right;
            }
            else if (_left)
            {
                // face in the direction the monkey is walking
                transform.localScale = new Vector3(-1 * _scale.x, _scale.y, _scale.z);
                transform.GetChild(0).localScale = new Vector3(-1 * _childscale.x, _childscale.y, _childscale.z);
                // move to the left 
                transform.position += Time.deltaTime * _speed * Vector3.left;
            }
        }
        else
        {
            // face in the direction the of the mouse if the monkey isn''t walking 
            if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x < 0)
            {
                transform.localScale = new Vector3(-1 * _scale.x, _scale.y, _scale.z);
                transform.GetChild(0).localScale = new Vector3(-1 * _childscale.x, _childscale.y, _childscale.z);
            }
            else
            {
                transform.localScale = _scale;
                transform.GetChild(0).localScale = _childscale;
            }
        }
    }

    // Change sprite depending on the current motion and action of the monkey
    IEnumerator SetSprite()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spriteratechagne);
            currSprite = spriteRenderer.sprite;
            if (_mousedown) //
            {
                spriteRenderer.sprite = monkeythrow1;
                transform.GetChild(0).localPosition = new Vector3(-0.4f,0.2f,0f);
                transform.GetChild(0).localRotation = new Quaternion(0f,0f,1f,-0.1f);
            }
            else if (currSprite == monkeythrow1)
            {
                spriteRenderer.sprite = monkeythrow2;
                transform.GetChild(0).localPosition = new Vector3(-2f,0.4f,0f);
                transform.GetChild(0).localRotation = new Quaternion(0f,0f,0.9f,0.4f);
            }
            else if (monkeyRB.velocity.y > 0.01f)
            {
                spriteRenderer.sprite = jumpstance;
                transform.GetChild(0).localPosition = new Vector3(0f,0.1f,0f);
                transform.GetChild(0).localRotation = new Quaternion(0f,0f,1.0f,-0.1f);
            }
            else if (_right != _left & monkeyRB.velocity.y < 1f & monkeyRB.velocity.y > -1f)
            {
                if (currSprite == walk1)
                {
                    spriteRenderer.sprite = walk2;
                    transform.GetChild(0).localPosition = new Vector3(0.1f,0f,0f);
                    transform.GetChild(0).localRotation = new Quaternion(0f,0f,0.4f,0.9f);
                }
                else if (currSprite == walk2)
                {
                    spriteRenderer.sprite = walk3;
                    transform.GetChild(0).localPosition = new Vector3(0.1f,-0.1f,0f);
                    transform.GetChild(0).localRotation = new Quaternion(0f,0f,0f,1f);
                }
                else if (currSprite == walk3)
                {
                    spriteRenderer.sprite = walk4;
                    transform.GetChild(0).localPosition = new Vector3(0f,-0.2f,0f);
                    transform.GetChild(0).localRotation = new Quaternion(0f,0f,0.2f,1f);
                }
                else
                {
                    spriteRenderer.sprite = walk1;
                    transform.GetChild(0).localPosition = new Vector3(0.1f,-0.1f,0f);
                    transform.GetChild(0).localRotation = new Quaternion(0f,0f,0f,1f);
                } 
            }
            else
            {
                spriteRenderer.sprite = standingsideways;
                transform.GetChild(0).localPosition = new Vector3(0f,-0.27f,0f);
                transform.GetChild(0).localRotation = new Quaternion(0f,0f,0f,0f);

            }
        }
    }

    // check the bounds of monkey 
    void LateUpdate(){
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, _screenposition.x - _halfWidth + _objectWidth, _screenposition.x + _halfWidth - _objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, _screenposition.y - _halfHeight + _objectHeight, _screenposition.y + _halfHeight - _objectHeight);
        if (viewPos.y >= 11.7)
        {
            monkeyRB.velocity =  new Vector3(0f,-0.7f,0f);
        }
        transform.position = viewPos;
    }

    // this might be helpful with fixing the jump.
    private void OnCollisionStay2D(Collision2D other)
    {
        
    }

    //check what platform the monkey is on and set the monkeys jumping speed
    private void OnCollisionEnter2D(Collision2D other)
    {
        GameObject GO = other.gameObject;
        switch (GO.tag) // which object has it collided with 
        {
            case "mushroom": 
                _jumpspeed = 200f;
                _jumped = false;
                break;
            case "Platform":
                _jumpspeed = 400f;
                _jumped = false;
                break;
        }
    }
}
