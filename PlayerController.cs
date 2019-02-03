using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{

    public float speed;

    public Text countText;
    public Text pickText;
    public Text WinText;
    public Text livesText;

    private int count;
    private Rigidbody rb;
    private int pickups;
    private int lives;
    void Start()
        
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        pickups = 0;
        lives = 3;
        setCountText();
        WinText.text = "";
        // countText.text = "Count:"+ count.ToString();
    }
    private void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();

    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count=count+1;
            pickups++;
            setCountText();

        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            count = count - 1;
            lives--;
            setCountText();

        }

    }
    void setCountText()
    {
        pickText.text = "Count:"+pickups.ToString();
        countText.text = "Score:" + count.ToString();
        livesText.text="Lives: "+lives.ToString();
        if (lives <= 0)
        {
            this.gameObject.SetActive(false);
            WinText.text = "You died!";
        }
        if (pickups==12)
        {
         transform.position=-new Vector3 (130f, -.5f, 8.72f);
        }

        if (count >= 20)
        {
            WinText.text = "You Win!";
        }
    }
}
/*
using UnityEngine;
using System.Collections;

public class ExampleClass : MonoBehaviour
{
    void Update()
    {
        // Move the object forward along its z axis 1 unit/second.
        transform.Translate(0, 0, Time.deltaTime);

        // Move the object upward in world space 1 unit/second.
        transform.Translate(0, Time.deltaTime, 0, Space.World);
    }
}
*/