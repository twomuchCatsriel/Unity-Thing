using System.Threading.Tasks;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class basicEnemy : MonoBehaviour
{
    GameObject DetectionRange;
    GameObject bulletRaw;
    Rigidbody2D rb2d;
    float timebetweenshots;
    public int bulletSpeed;
    public int health = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DetectionRange = gameObject.transform.Find("Enemy_Detection_Range").gameObject;
        bulletRaw = gameObject.transform.Find("Bullet").gameObject;
        rb2d = GetComponent<Rigidbody2D>();
        timebetweenshots = 1;

    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            timebetweenshots -= Time.deltaTime;

            if (timebetweenshots <= 0)
            {

                if (collision.transform.position.x > gameObject.transform.position.x)
                {
                    Debug.Log("Player is too the right");
                    createBullet(0);
                }
                else if (collision.transform.position.x < gameObject.transform.position.x)
                {
                    Debug.Log("Player is too the left");
                    createBullet(1);
                }
                timebetweenshots = 2;
            }
        }
    }

    void createBullet(int dir)
    {
        GameObject CloneBullet = Instantiate(bulletRaw);
        CloneBullet.transform.position = gameObject.transform.position;

        Rigidbody2D rb = CloneBullet.GetComponent<Rigidbody2D>();
        // 1 or 0 depending on the direction of the bullet

        if (dir == 0)
        {
            rb.linearVelocity = new Vector2(bulletSpeed, 0.5f) * 5;
        }
        else
        {
            rb.linearVelocity = new Vector2(-bulletSpeed, 0.5f) * 5;
        }

        Destroy(CloneBullet, 5f);
    }
}