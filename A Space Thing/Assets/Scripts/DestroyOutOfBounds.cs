using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{

    private int leftLimit = -13;
    private int rightLimit = 15;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < leftLimit)
        {
            Destroy(gameObject);
            gameManager.UpdateScore(-1);

        }

        else if (transform.position.x > rightLimit)
        {
           Destroy(gameObject);
        }
    }
}
