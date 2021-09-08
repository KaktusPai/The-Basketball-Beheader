using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Move : MonoBehaviour
{ 
    public float moveSpeed = 5f;
    public float kills;

    public Rigidbody2D rb;
    public Rigidbody2D throwrb;
    public Camera cam;
    public Transform playerpos;
    public GameObject player;
    public Text scoreText;
    public Text winText;

    public Vector2 movement;
    public Vector2 mousePos;

    public SpriteRenderer sr;
    public int FrameLength = 50;
    bool walk = true;
    public Sprite walk1;
    public Sprite walk2;
    public Sprite throw1;
    public Sprite throw2;
    public int time;

    void Start()
    {
        winText.gameObject.SetActive(false);
    }
    void Update()
    {
        scoreText.text = "Assasinations " + kills + "/6";
        if (player.GetComponent<Throw>().mouseDown == false)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        } else if (player.GetComponent<Throw>().mouseDown == true)
        {
            movement = Vector3.zero;
        }
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (kills == 6)
        {
            winText.gameObject.SetActive(true);
        }
    }

    //Movement
    void FixedUpdate()
    {
        WalkAnimation();
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        throwrb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - throwrb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        throwrb.rotation = angle;
    }

    void WalkAnimation()
    {
        if (walk == true)
        {
            time++;
            if (time == FrameLength)
            {
                if (movement.x == 1)
                {
                    sr.flipX = true;
                } else if (movement.x == -1)
                {
                    sr.flipX = false;
                }
                sr.sprite = walk2;
                time = time - (FrameLength * 2);
            }
            else if (time > 0)
            {
                if (movement.x == 1)
                {
                    sr.flipX = true;
                }
                else if (movement.x == -1)
                {
                    sr.flipX = false;
                }
                sr.sprite = walk1;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(1);
    }
}
