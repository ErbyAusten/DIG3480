using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    Animator anim;
    private Rigidbody2D rb2d;
    public float speed;
    public float jumpForce;
    public AudioClip won;
    public AudioSource musicSource;

    public Text countText;
    public Text pickText;
    public Text WinText;
    public Text livesText;

    private bool facingRight = true;


    private int pickups;
    private int lives;
    private int count;
    // Use this for initialization
    void Start() {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        pickups = 0;
        count = 0;
        lives = 3;

        setCountText();
        WinText.text = "";
    }

    // Update is called once per frame
    void Update() {
    
        if (Input.GetKeyDown(KeyCode.D))
        {
            facingRight = true;
            anim.SetInteger("state", 1);
              
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            facingRight = true;
            anim.SetInteger("state", 0);
        }

        if (Input.GetKeyDown(KeyCode.A)) {
            facingRight = false;
             anim.SetInteger("state", 1);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            facingRight = false;
            anim.SetInteger("state", 0);
        }
        if (Input.GetKey("escape"))
            Application.Quit();




    }



    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        if (facingRight == false && moveHorizontal > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveHorizontal < 0)
        {
            Flip();
        }

        Vector2 movement = new Vector2(moveHorizontal, 0);

        rb2d.AddForce(movement * speed);




    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector2 Scaler = transform.localScale;
        Scaler.x = Scaler.x * -1;
        transform.localScale = Scaler;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag=="Ground"){

            if (Input.GetKey(KeyCode.UpArrow)){
                rb2d.AddForce(new Vector2(0,jumpForce), ForceMode2D.Impulse);
                anim.SetInteger("state", 3);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count ++;
            pickups++;
            setCountText();

        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
         //   count = count - 1;
            lives--;
            setCountText();

        }

    }
    void setCountText()
    {
     //   pickText.text = "Count:" + pickups.ToString();
        countText.text = "Score:" + count.ToString();
        livesText.text = "Lives: " + lives.ToString();
        if (lives <= 0)
        {
            this.gameObject.SetActive(false);
            WinText.text = "You  Lose!";
        }
        if (pickups == 4)
        {
              lives = 3;
            transform.position = -new Vector2(-34f, 0f);
        }

        if (count >=8)
        {
            musicSource.clip = won;
            musicSource.Play();
            musicSource.loop = false;
            WinText.text = "You Win!";
        }
    }

}
