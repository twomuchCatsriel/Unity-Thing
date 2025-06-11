using UnityEngine;

public class enemyHealthManager : MonoBehaviour
{
    public float health;

    public void CheckHealth()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Damage(float dmg)
    {
        health -= dmg;
    }
}
