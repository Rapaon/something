using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scores : MonoBehaviour
{

    public Text highScoreTxt1;
    public Text scoreTxt1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameManager gameManager = FindObjectOfType<GameManager>(); 
        scoreTxt1.text = "Your score: " + gameManager.score.ToString();
        highScoreTxt1.text = "High score: " + gameManager.highScore.ToString();
        
    }
}
