using Unity.VisualScripting;
using UnityEngine;

public class hitboxScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemies"))
        {
            enemyHealthManager script = collision.GetComponent<enemyHealthManager>();
            script.Damage(1);
            script.CheckHealth();
        }
    }
}