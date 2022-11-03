using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int moveSpeed;
    //public ParticleSystem explosion;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
       
    }

   /* private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);

        if (other.gameObject.CompareTag("Missle"))
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Debug.Log("EXPLOSION!!");
            // explosion.Play();
        }
    }*/


    /*    private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Missle"))
            {
                // explosion.Play();
                Debug.Log("EXPLOSION");
            }
        }*/
}
