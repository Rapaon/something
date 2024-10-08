using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid2 : MonoBehaviour
{
    public int size = 3;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = 0.5f * size * Vector3.one;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 direction = new Vector2(Random.value, Random.value).normalized;
        float spawnSpeed = Random.Range(4f - size, 5f - size);
        rb.AddForce(direction * spawnSpeed, ForceMode2D.Impulse);

        gameManager.asteroid2Count++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("projectile"))
        {
            gameManager.asteroid2Count--;
            gameManager.score += 1;
            Destroy(collision.gameObject);
            
            if (size > 1)
            {
                for (int i = 0; i < 2; i++)
                {
                    Asteroid2 newAsteroid2 = Instantiate(this, transform.position, Quaternion.identity);
                    newAsteroid2.size = size - 1;
                    newAsteroid2.gameManager = gameManager;

                }
            }

            Destroy(gameObject);
        }
    }
}
