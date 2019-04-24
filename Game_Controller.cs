using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Controller : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public Text scoreText;
    public Text gameOverText;
    public Text restartText;
    public Text hardmodeText;
    public AudioSource win;
    public AudioSource lose;
    private WeaponController weaponCont;
    public bool victory;
    public bool hardMode;
    private bool gameOver;
    private bool restart;
    private AudioSource hello;
    public int score;
    private Mover move;
    private void Awake()
    {
        hardMode = false;
    }

    void Start()
    {
        victory = false;

        hello = GetComponent<AudioSource>();
        hardMode = false;
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        hardmodeText.text = "Press \"H\" for hardmode";
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0,hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            if (gameOver)
            {
                restartText.text = "Press 'Space' to Restart";
                restart = true;
                break;
            }

        }

    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Points: " + score;
        if (score >= 100)
        {
            hello.Pause();
            win.Play();
            victory = true;
            gameOverText.text = "You won! "+"\n\nGame Created by Allison Erby!";
            gameOver = true;
        }
    }

    public void GameOver()
    {

        //hello = this.AudioSource;
        hello.Pause();
        lose.Play();
        gameOverText.text = "Game Over!";
        gameOver = true;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            SceneManager.LoadScene("HardMode");
            
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("SpaceShooter");
        }

            if (restart)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("SpaceShooter"); // or whatever the name of your scene is
            }
        }
        if (Input.GetKey("escape"))
            Application.Quit();
    }


}