using UnityEngine;

public class AsteroidCollision : MonoBehaviour
{
    private float minX;
    private float maxX;
    private float minY;
    private float maxY;

    private bool seen;

    private float rotationSpeed;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //foreach (ContactPoint contact in collision.contacts)
        //{
        //    Debug.DrawRay(contact.point, contact.normal, Color.white);
        //}

        //if (collision.transform.CompareTag("Wall"))
        //{
        //    var x = collision.collider;
        //    var z = GetComponent<Collider2D>();

        //    Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        //}

        //if (collision.relativeVelocity.magnitude > 2)
        //    audioSource.Play();
    }

    private void Start()
    {
        var lowerLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        var upperRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        minX = lowerLeft.x - 5f;
        maxX = upperRight.x + 5f;
        maxY = upperRight.y + 5f;
        minY = lowerLeft.y - 5f;

        rotationSpeed = Random.Range(-200f, 200f);
    }

    void Update()
    {
        if (!seen &&
            (transform.position.x < maxX &&
            transform.position.x > minX &&
            transform.position.y < maxY &&
            transform.position.y > minY))
            seen = true;

        if (seen &&
            (transform.position.x < minX ||
            transform.position.x > maxX ||
            transform.position.y < minY ||
            transform.position.y > maxY))
            Destroy(gameObject);


        transform.Rotate(new Vector3(0, 0, (transform.rotation.z + rotationSpeed) * Time.deltaTime % 360));
    }
}
