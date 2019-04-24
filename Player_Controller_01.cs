using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class Player_Controller_01 : MonoBehaviour
{
    public float speed;
    public float tilt;
    public Boundary boundary;
    private float initial;
    public GameObject explosion;
    public GameObject playerExplosion;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;
    public AudioSource clip;
    private Rigidbody rb;
 
    private float setting;
    private float he;
    public DestroyByContact Dest;
    private void Start()
    {

        rb = GetComponent<Rigidbody>();

        he= fireRate;
        initial = speed;
    }

    void Update()
    {
        clip = GetComponent<AudioSource>();
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            clip.Play(0);
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;


        rb.position = new Vector3
        (
             Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
             0.0f,
             Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }
    void OnTriggerEnter(Collider other)
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        initial = speed;
        he = fireRate;
        if (other.tag == "PowerUp")
        {
      
            Debug.Log("Should Power Up timer= %f");
            Instantiate(explosion, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
       
 
                fireRate = fireRate / 3;
                speed = speed * (3/2);



        }
    }

}