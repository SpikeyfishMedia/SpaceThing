using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   // public int lives;
    public int moveSpeed;
    private float verticalInput;
    public GameObject projectile;
    private float verticalRange;
    public GameManager gameManager;
    public bool isGameOver;
    private Vector3 offset;
    private AudioSource gunAudio;
    public AudioClip weaponFire;
    public ParticleSystem deathExplosion;
   

    // Start is called before the first frame update
    void Start()
    {
        verticalRange = 3.9f;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        // isGameOver = gameManager.gameOver;
        offset = new Vector3(.40f, -.15f, 0);
        gunAudio = GetComponent<AudioSource>();
        
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!gameManager.gameOver)
        {
        if (transform.position.y < -verticalRange)
        {
            transform.position = new Vector3(transform.position.x, -verticalRange, transform.position.z);
        }

        if (transform.position.y > verticalRange)
        {
            transform.position = new Vector3(transform.position.x, verticalRange, transform.position.z);
        }

            verticalInput = Input.GetAxis("Vertical");
            // transform.position.y * verticalInput*Time.deltaTime;
            transform.Translate(Vector3.up * verticalInput * Time.deltaTime * moveSpeed);

        }

        if (gameManager.gameOver)
        {
            Instantiate<ParticleSystem>(deathExplosion, transform.position, transform.rotation);
            gameObject.SetActive(false);
        }



        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!gameManager.gameOver)
            {
                FireLaser();
            }
           
        }

    }

    void FireLaser()
    {
        projectile.transform.position = transform.position + offset;
        Instantiate<GameObject>(projectile);
        gunAudio.PlayOneShot(weaponFire, 1.0f);
    }

}
