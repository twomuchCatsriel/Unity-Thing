using UnityEngine;

public class enemySlashHitbox : MonoBehaviour
{
    public bool playerIsInRange = false;
    public float defaultCooldown;
    bool playerIsRight = false;

    float currentCooldown = 0.5f;

    GameObject hitbox;
    GameObject meleeEnemy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        meleeEnemy = gameObject.transform.parent.gameObject;
        hitbox = gameObject.transform.parent.GetChild(2).gameObject;
        playerIsInRange = false;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            currentCooldown -= Time.deltaTime;

            if (currentCooldown < 0)
            {
                Attack();
            }
        }
    }

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

    void Attack()
    {
        
    }
}
