using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public GameManager gameManager;
    public ParticleSystem enemyExplosion;
    

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
       // enemyExplosion = GameObject.Find("WFX_Explosion StarSmoke").GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {


        // Debug.Log("HIT");
        // Debug.Log(other.gameObject.tag);

        if (other.gameObject.name == "PlayerShip")
        {
            //Debug.Log("You lost a life");
            Destroy(gameObject);
            Instantiate<ParticleSystem>(enemyExplosion, gameObject.transform.position, gameObject.transform.rotation);
            gameManager.PlayExplosion();
            gameManager.UpdateLife(-1);

        }

        if (other.gameObject.CompareTag("Missle"))
        {
            //Debug.Log("You scored a point");
            Destroy(gameObject);
            Destroy(other.gameObject);
            Instantiate<ParticleSystem>(enemyExplosion, gameObject.transform.position, gameObject.transform.rotation);
            gameManager.PlayExplosion();
            gameManager.UpdateScore(1);
        }

    }

}
