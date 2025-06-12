using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class meleeEnemy : MonoBehaviour
{

    public float patrolRange;
    public float walkSpeed;

    Animator anim;
    SpriteRenderer sr;
    Rigidbody2D rb;

    bool playerDetected = false;
    bool playerInAttackRange = false;
    bool direction = false;

    GameObject enemyAttackRange;
    GameObject enemyDetectionRange;
    GameObject hitbox;

    float maxPatrolLeft;
    float maxPatrolRight;
    float destination;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        enemyAttackRange = gameObject.transform.Find("Enemy_Attack_Range").gameObject;
        enemyDetectionRange = gameObject.transform.Find("Enemy_Detection_Range").gameObject;
        hitbox = gameObject.transform.Find("Enemy_Swing_Hitbox").gameObject;

        maxPatrolLeft = gameObject.transform.position.x - patrolRange;
        maxPatrolRight = gameObject.transform.position.x + patrolRange;

        int random = Random.Range(0, 2);

        if (random == 0)
        {
            destination = maxPatrolLeft;
            direction = false;
        }
        else
        {
            destination = maxPatrolRight;
            direction = true;
        }

        Debug.Log(random);
    }

    // Update is called once per frame
    void Update()
    {
        float currentPositionX = gameObject.transform.position.x;
        if (direction == false) // Left
        {
            if (currentPositionX > maxPatrolLeft)
            {
                destination = maxPatrolLeft;
                rb.linearVelocity = new Vector2(-walkSpeed, rb.linearVelocityY);
            }

            if (currentPositionX <= maxPatrolLeft)
            {
                direction = !direction;
            }
        }

        else if (direction)
        {
            if (currentPositionX < maxPatrolRight)
            {
                destination = maxPatrolRight;
                rb.linearVelocity = new Vector2(walkSpeed, rb.linearVelocityY);
            }

            if (currentPositionX >= maxPatrolRight)
            {
                direction = !direction;
            }
        }
    }
}
