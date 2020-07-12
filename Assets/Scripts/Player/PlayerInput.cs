using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [Range(0, 100)]
    public float thrustForce = 10f;

    [Range(0, 360)] 
    public float rotationSpeed = 330f;

    public Animator Animator;

    private Rigidbody2D player;

    private void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // Rotate the ship
        if (player.velocity.magnitude != 0)
            player.transform.Rotate(0, 0, -Input.GetAxis("Horizontal") *
                rotationSpeed * Time.deltaTime);

        // Thrust the ship
        var thrust = Input.GetAxis("Vertical");
        player.AddForce(transform.up * thrustForce * thrust);

        if (thrust != 0)
            Animator.SetTrigger("Thrust");
        else
            Animator.ResetTrigger("Thrust");
    }
}
