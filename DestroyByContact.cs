using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;

    private Game_Controller GameController;
    private Player_Controller_01 weaponcont;
 
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
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy")||(other.CompareTag("PowerUp")))
        {
            return;
        }

        if (explosion != null&&!(other.CompareTag("PowerUp")))
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }

        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            GameController.GameOver();
        }



        GameController.AddScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
 
}