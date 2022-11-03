using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaunchGame : MonoBehaviour
{
    public GameObject planet;
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        planet.transform.Rotate(Vector3.down * rotationSpeed * Time.deltaTime);
    }

   public void LoadGameScene()
    {
        SceneManager.LoadScene(1);
    }
}
