using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject enemyShip;
    public float topLimit;
    public float bottomLimit;
    public int score;
    public bool gameOver;
    public int life;

   // public ParticleSystem explosion;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI lifeText;
    public TextMeshProUGUI gameOverText;
    private AudioSource playerAudio;
    private AudioSource backgroundMusic;
    public AudioClip explosionSound;
    public AudioClip mainGameMusic;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("LaunchEnemyShip", 2, 1);
        gameOver = false;
        score = 0;
        life = 3;
        scoreText.text = "Score: " + score;
        lifeText.text = "Lives Remaining: " + life;
       // explosion.transform.position = transform.position;
        AudioSource[] gameAudio = GetComponents<AudioSource>();
        playerAudio = gameAudio[1];
        backgroundMusic = gameAudio[0];
        //backgroundMusic = GetComponent<AudioSource>();
        backgroundMusic.clip = mainGameMusic;
        backgroundMusic.loop = true;
        backgroundMusic.volume = .50f;
        backgroundMusic.Play();

        //playerAudio.volume = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void LaunchEnemyShip()
    {
        if (gameOver)
        {
            CancelInvoke();
        }
        Vector3 randomPOS = new Vector3(11.5f, Random.Range(topLimit, bottomLimit), 0);
        enemyShip.transform.position = randomPOS;
        Instantiate<GameObject>(enemyShip);
       // Debug.Log("Ship Deployed");
    }

    public void UpdateScore(int pointsToAdd)
    {

        score += pointsToAdd;

        if (score <= 0) {
           //Debug.Log("Step 1");
            score = 0;
            scoreText.text = "Score: " + score;
        }
        else
        {
            //Debug.Log("Step 2");
            //score += pointsToAdd;
            scoreText.text = "Score: " + score;
        }
        
    }

   public void UpdateLife(int amountToAdjust)
    {
        life += amountToAdjust;

        if (life < 0)
        {
            life = 0;
            lifeText.text = "Lives Remaining: " + life;
            GameOver();
        }
        else
        {
            lifeText.text = "Lives Remaining: " + life;

        }


  
    }

    public void PlayExplosion()
    {
        Debug.Log("Sound Played");
        playerAudio.PlayOneShot(explosionSound, 1.0f);
        //playerAudio.PlayOneShot(explosionSound);
    }

      void GameOver()
        {
            gameOver = true;
            gameOverText.gameObject.SetActive(true);
        }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
