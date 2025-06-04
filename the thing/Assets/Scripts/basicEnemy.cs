using UnityEngine;

public class basicEnemy : MonoBehaviour
{
    public GameObject plr;
    GameObject DetectionRange;
    Rigidbody2D rb2d;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DetectionRange = gameObject.transform.Find("Enemy_Detection_Range").gameObject;
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
}
