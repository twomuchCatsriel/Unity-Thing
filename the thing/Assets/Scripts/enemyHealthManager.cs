using UnityEngine;

public class enemyHealthManager : MonoBehaviour
{
    public float health;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FriendlyProjectiles"))
        {
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
