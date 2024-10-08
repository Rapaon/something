using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private Asteroid asteroidPrefab;
    [SerializeField] private Asteroid1 asteroid1Prefab;
    [SerializeField] private Asteroid2 asteroid2Prefab;
    [SerializeField] private Asteroid3 asteroid3Prefab;
    
    public int asteroidCount = 0;
    public int asteroid1Count = 0;
    public int asteroid2Count = 0;
    public int asteroid3Count = 0;
    public int score = 0;
    public int highScore = 0;
    public int health = 3;
    public Text scoreTxt;
    public Text highScoreTxt;
    private int level = 0;

    // Awake is called before Start, used for initialization
    private void Awake()
    {
        // Singleton pattern - ensures only one instance of GameManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicates
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        // Update the UI with the current score and health
        UpdateUI();
        highScore = PlayerPrefs.GetInt("highScore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();

        if (asteroidCount == 0)
        {
            level++;
            int numAsteroids = 1 + (0 * level);
            for (int i = 0; i < numAsteroids; i++)
            {
                SpawnAsteroid();
            }
        }

        if (asteroid1Count == 0)
        {
            level++;
            int numAsteroids1 = 1 + (0 * level);
            for (int i = 0; i < numAsteroids1; i++)
            {
                SpawnAsteroid1();
            }
        }

        if (asteroid2Count == 0)
        {
            level++;
            int numAsteroids2 = 1 + (0 * level);
            for (int i = 0; i < numAsteroids2; i++)
            {
                SpawnAsteroid2();
            }
        }

        if (asteroid3Count == 0)
        {
            level++;
            int numAsteroids3 = 1 + (0 * level);
            for (int i = 0; i < numAsteroids3; i++)
            {
                SpawnAsteroid3();
            }
        }
    }

    private void UpdateUI()
    {
        scoreTxt.text = score.ToString();
        if (highScore < score)
        {
            PlayerPrefs.SetInt("highScore", score);
        }
        highScoreTxt.text = highScore.ToString();
    }

    private void SpawnAsteroid()
    {
        float offset = Random.Range(0f, 1f);
        Vector2 viewportSpawnPosition = Vector2.zero;
        int edge = Random.Range(0, 4);
        if (edge == 0)
        {
            viewportSpawnPosition = new Vector2(offset, 0);
        }
        else if (edge == 1)
        {
            viewportSpawnPosition = new Vector2(offset, 1);
        }
        else if (edge == 2)
        {
            viewportSpawnPosition = new Vector2(0, offset);
        }
        else if (edge == 3)
        {
            viewportSpawnPosition = new Vector2(1, offset);
        }

        Vector2 worldSpawnPosition = Camera.main.ViewportToWorldPoint(viewportSpawnPosition);
        Asteroid asteroid = Instantiate(asteroidPrefab, worldSpawnPosition, Quaternion.identity);
        asteroid.gameManager = this;
    }

    private void SpawnAsteroid1()
    {
        float offset = Random.Range(0f, 1f);
        Vector2 viewportSpawnPosition = Vector2.zero;
        int edge = Random.Range(0, 4);
        if (edge == 0)
        {
            viewportSpawnPosition = new Vector2(offset, 0);
        }
        else if (edge == 1)
        {
            viewportSpawnPosition = new Vector2(offset, 1);
        }
        else if (edge == 2)
        {
            viewportSpawnPosition = new Vector2(0, offset);
        }
        else if (edge == 3)
        {
            viewportSpawnPosition = new Vector2(1, offset);
        }

        Vector2 worldSpawnPosition = Camera.main.ViewportToWorldPoint(viewportSpawnPosition);
        Asteroid1 asteroid1 = Instantiate(asteroid1Prefab, worldSpawnPosition, Quaternion.identity);
        asteroid1.gameManager = this;
    }

    private void SpawnAsteroid2()
    {
        float offset = Random.Range(0f, 1f);
        Vector2 viewportSpawnPosition = Vector2.zero;
        int edge = Random.Range(0, 4);
        if (edge == 0)
        {
            viewportSpawnPosition = new Vector2(offset, 0);
        }
        else if (edge == 1)
        {
            viewportSpawnPosition = new Vector2(offset, 1);
        }
        else if (edge == 2)
        {
            viewportSpawnPosition = new Vector2(0, offset);
        }
        else if (edge == 3)
        {
            viewportSpawnPosition = new Vector2(1, offset);
        }

        Vector2 worldSpawnPosition = Camera.main.ViewportToWorldPoint(viewportSpawnPosition);
        Asteroid2 asteroid2 = Instantiate(asteroid2Prefab, worldSpawnPosition, Quaternion.identity);
        asteroid2.gameManager = this;
    }

    private void SpawnAsteroid3()
    {
        float offset = Random.Range(0f, 1f);
        Vector2 viewportSpawnPosition = Vector2.zero;
        int edge = Random.Range(0, 4);
        if (edge == 0)
        {
            viewportSpawnPosition = new Vector2(offset, 0);
        }
        else if (edge == 1)
        {
            viewportSpawnPosition = new Vector2(offset, 1);
        }
        else if (edge == 2)
        {
            viewportSpawnPosition = new Vector2(0, offset);
        }
        else if (edge == 3)
        {
            viewportSpawnPosition = new Vector2(1, offset);
        }

        Vector2 worldSpawnPosition = Camera.main.ViewportToWorldPoint(viewportSpawnPosition);
        Asteroid3 asteroid3 = Instantiate(asteroid3Prefab, worldSpawnPosition, Quaternion.identity);
        asteroid3.gameManager = this;
    }

    public void GameOver()
    {
        StartCoroutine(Restart());
    }

    private IEnumerator Restart()
    {
        Debug.Log("Game over");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1); // Assuming your Game Scene is at build index 1
    }
}
