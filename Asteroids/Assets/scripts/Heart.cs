using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public int heartCount = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameManager gameManager = FindObjectOfType<GameManager>(); 
          if (gameManager != null)
          {
            if (gameManager.health <= heartCount)
            {
             Destroy(gameObject);
            }          
          }
        
    }
}
