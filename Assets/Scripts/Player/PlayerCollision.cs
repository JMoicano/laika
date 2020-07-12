using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameController gameController;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var hitable = collision.gameObject.GetComponent<Hitable>();

        if (hitable != null)
        {
            //gameController.TakeDamage(hitable.HitDamage);
            Debug.Log($"Hit {collision.collider.name} for {hitable.HitDamage} hit points.");
        }

        gameController.CurrentHeat += 30;
    }
}
