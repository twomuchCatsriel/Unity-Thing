using UnityEngine;

public class bulletHitScript : MonoBehaviour
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemies"))
        {
            enemyHealthManager enemyHP = collision.gameObject.GetComponent<enemyHealthManager>();

            enemyHP.Damage(0.5f);
            enemyHP.CheckHealth();

            Destroy(gameObject);
        }
    }
}
