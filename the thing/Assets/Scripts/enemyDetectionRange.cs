using UnityEngine;

public class enemyDetectionRange : MonoBehaviour
{
    public bool playerIsInRange = false;
    public bool playerIsRight = false;
    public Vector2 playerPosition = new Vector2(0, 0);
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsInRange = true;

        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsInRange = false;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerPosition = collision.transform.position;

            if (collision.gameObject.transform.position.x > gameObject.transform.position.x)
            {
                playerIsRight = false;
                Debug.Log("Facing Left");
            }
            else if (collision.gameObject.transform.position.x < gameObject.transform.position.x)
            {
                playerIsRight = true;
                Debug.Log("Facing Right");
            }
        }
    }
}

