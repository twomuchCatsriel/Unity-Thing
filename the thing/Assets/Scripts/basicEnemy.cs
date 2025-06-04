using UnityEngine;

public class basicEnemy : MonoBehaviour
{
    public GameObject plr;
    GameObject DetectionRange;
    GameObject bulletRaw;
    Rigidbody2D rb2d;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DetectionRange = gameObject.transform.Find("Enemy_Detection_Range").gameObject;
        bulletRaw = gameObject.transform.Find("bullet").gameObject;
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.transform.position.x > gameObject.transform.position.x)
            {
                Debug.Log("Player is too the right");
            }
            else if (collision.transform.position.x < gameObject.transform.position.x)
            {
                Debug.Log("Player is too the left");
            }
            else if (collision.transform.position.x == gameObject.transform.position.x)
            {
                Debug.Log("Player is on top.");
            }
        }
    }

    void createBullet(int dir)
    {
        GameObject CloneBullet = Instantiate(bulletRaw);
        Rigidbody2D rb = CloneBullet.GetComponent<Rigidbody2D>();
        // 1 or 0 depending on the direction of the bullet

        if (dir == 0)
        {
            
        }
    }
}