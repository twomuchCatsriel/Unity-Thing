using UnityEngine;

public class enemyDetectionRange : MonoBehaviour
{
    public bool playerIsInRange = false;
    public Vector2 playerPosition = new Vector2(0,0);
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsInRange = true;
            Debug.Log(playerIsInRange);

        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsInRange = false;
            Debug.Log(playerIsInRange);
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerPosition = collision.transform.position;
        }
    }
}
