using System.Linq.Expressions;
using Mono.Cecil;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class meleeEnemy : MonoBehaviour
{

    public float patrolRange;
    public float walkSpeed;
    public float runSpeed;

    Animator anim;
    SpriteRenderer sr;
    Rigidbody2D rb;

    bool direction = true;

    enemyDetectionRange detectRangeScript;
    enemySlashHitbox enemySlash;
    GameObject edr;
    GameObject esh;

    float maxPatrolLeft;
    float maxPatrolRight;
    float destination;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        edr = gameObject.transform.Find("Enemy_Detection_Range").gameObject;
        esh = gameObject.transform.Find("Enemy_Attack_Range").gameObject;

        detectRangeScript = edr.GetComponent<enemyDetectionRange>();
        enemySlash = esh.GetComponent<enemySlashHitbox>();

        maxPatrolLeft = gameObject.transform.position.x - patrolRange;
        maxPatrolRight = gameObject.transform.position.x + patrolRange;
    }

    // Update is called once per frame
    void Update()
    {
        float currentPositionX = gameObject.transform.position.x;

        if (detectRangeScript.playerIsInRange == false)
        {
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
                    sr.flipX = false;
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
                    sr.flipX = true;
                }
            }
        }
        else
        {
            if (enemySlash.playerIsInRange == false)
            {
                if (detectRangeScript.playerPosition.x < gameObject.transform.position.x)
                {
                    rb.linearVelocity = new Vector2(-runSpeed, rb.linearVelocityY);
                    sr.flipX = true;
                }
                else if (detectRangeScript.playerPosition.x > gameObject.transform.position.x)
                {
                    rb.linearVelocity = new Vector2(runSpeed, rb.linearVelocityY);
                    sr.flipX = false;
                }
            }
            else
            {
                rb.linearVelocity = new Vector2(0, rb.linearVelocityY);
            }
        }
    }
}