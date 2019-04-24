using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
    public float speed;
    private float r;
    private Game_Controller GameController;
    private Rigidbody rb;
    private bool hello;
 


  
    void Start()
    {

        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            GameController = gameControllerObject.GetComponent<Game_Controller>();
        }
        if (GameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }


        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
     

    }
    private void Update()
    {
   //     if (GameController.hardMode == true)
   //     {
  //          speed = -100;
    //        rb = GetComponent<Rigidbody>();
    //        rb.velocity = transform.forward * speed;
   //     }
//
  //      rb = GetComponent<Rigidbody>();
  //      rb.velocity = transform.forward * speed;
    }
}