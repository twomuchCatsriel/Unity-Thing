using UnityEngine;

public class nikoProjHit : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyProjectiles"))
        {
            Debug.Log("Hit by " + collision.name);
        }
    }
}
