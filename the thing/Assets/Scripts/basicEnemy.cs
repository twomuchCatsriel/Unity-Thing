using System.Threading.Tasks;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class basicEnemy : MonoBehaviour
{
    GameObject DetectionRange;
    GameObject bulletRaw;
    Rigidbody2D rb2d;
    SpriteRenderer sr;
    Animator anim;

    float timebetweenshots;
    bool playerSide = false;
    public int bulletSpeed;
    public Sprite lookSprite;
    public Sprite stareSprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DetectionRange = gameObject.transform.Find("Enemy_Detection_Range").gameObject;
        bulletRaw = gameObject.transform.Find("Bullet").gameObject;
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        timebetweenshots = 1;

    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            timebetweenshots -= Time.deltaTime;

            if (collision.transform.position.x > gameObject.transform.position.x) // check if the player is left or right
            {
                ManageAnimations(false);
            }
            else
            {
                ManageAnimations(true);
            }


            if (timebetweenshots <= 0)
            {

                if (playerSide == false)
                {
                    Debug.Log("Player is too the right");

                    createBullet(0);
                }
                else if (playerSide == true)
                {
                    Debug.Log("Player is too the left");

                    createBullet(1);
                }
                timebetweenshots = 2;
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        sr.sprite = stareSprite;
    }

    void createBullet(int dir)
    {
        GameObject CloneBullet = Instantiate(bulletRaw);
        CloneBullet.transform.position = gameObject.transform.position;

        Rigidbody2D rb = CloneBullet.GetComponent<Rigidbody2D>();
        // 1 or 0 depending on the direction of the bullet

        if (dir == 0)
        {
            rb.linearVelocity = new Vector2(bulletSpeed, 0.6f) * 5;
        }
        else
        {
            rb.linearVelocity = new Vector2(-bulletSpeed, 0.6f) * 5;
        }

        Destroy(CloneBullet, 5f);
    }

    void ManageAnimations(bool dir)
    {
        if (timebetweenshots <= 0)
        {
            setPlayerSide(dir);
            anim.Play("Barrens_Ranged_Look");
        }
        else if(timebetweenshots <= 0.75)
        {
            setPlayerSide(dir);
            anim.Play("Barrens_Ranged_Shoot");
        }
    }

    void setPlayerSide(bool dir) // This is such a messy way to do this but it works lmfao
    {
        if (!dir)
        {
            playerSide = false;
            sr.flipX = playerSide;
        }
        else
        {
            playerSide = true;
            sr.flipX = playerSide;
        }
    }
}
