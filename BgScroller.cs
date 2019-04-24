using UnityEngine;
using System.Collections;

public class BgScroller : MonoBehaviour
{

    public float scrollSpeed;
    public float tileSizeZ;
    private float init;

    private Vector3 startPosition;

    private Game_Controller GameController;
    void Start()
    {
        startPosition = transform.position;
        init = scrollSpeed;

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

    void Update()
    {


        //   float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
        // transform.position = startPosition + Vector3.forward * newPosition;
        if (GameController.victory == false)
        {
            scrollSpeed = -1;


        }
        else if (scrollSpeed >= -80)
        {
            scrollSpeed -= (Time.deltaTime % 2);

        }





        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition + Vector3.forward * newPosition;

    }
}