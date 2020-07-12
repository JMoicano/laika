using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public bool stopSpawning;
    public float spawnTime;
    public float spawnDelay;

    public GameObject Asteroid01;
    public GameObject Asteroid02;
    public GameObject Asteroid03;

    private List<GameObject> _asteroids;

    private float minY;
    private float maxY;
    private float maxX;

    void Start()
    {
        _asteroids = new List<GameObject> { Asteroid01, Asteroid02, Asteroid03 };

        var lowerLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        var upperRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        maxY = upperRight.y;
        minY = lowerLeft.y;
        maxX = upperRight.x + 5f;

        InvokeRepeating("SpawnAsteroid", spawnTime, spawnDelay);
    }

    public void SpawnAsteroid()
    {
        if (stopSpawning)
        {
            CancelInvoke("SpawnAsteroid");
            return;
        }

        var pos = transform.position;

        pos.y = Random.Range(minY, maxY);
        pos.x = Random.Range(maxX, maxX + 10);

        transform.position = pos;

        var asteroid = Instantiate(_asteroids[Random.Range(0, 2)], transform.position, transform.rotation);

        var collider = asteroid.GetComponent<Collider2D>();

        Physics2D.IgnoreCollision(collider, GameObject.Find("SouthernWalls").GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(collider, GameObject.Find("NorthernWall").GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(collider, GameObject.Find("WesternWalls").GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(collider, GameObject.Find("EasternWalls").GetComponent<Collider2D>());

        var rb = asteroid.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.velocity = new Vector2(Random.Range(-3f, -5f), 0f);
        }
    }
}
