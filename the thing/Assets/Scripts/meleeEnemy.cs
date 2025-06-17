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

    bool direction = false;

    enemyDetectionRange detectRangeScript;
    enemySlashHitbox enemySlash;
    GameObject edr;
    GameObject esh;

    float maxPatrolLeft;
    float maxPatrolRight;
    float destination;

    float canSwitchAnim = 0;
    bool playingSwitch = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
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

        if (canSwitchAnim < 0)
        {
            playingSwitch = false;
        }

        canSwitchAnim -= Time.deltaTime;

        if (detectRangeScript.playerIsInRange == false)
        {
            if (direction == false) // Left
            {
                if (currentPositionX > maxPatrolLeft && playingSwitch == false)
                {
                    destination = maxPatrolLeft;
                    rb.linearVelocity = new Vector2(-walkSpeed, rb.linearVelocityY);
                    anim.Play("Barrens_Melee_Patrol_Walk");
                }

                if (currentPositionX <= maxPatrolLeft)
                {
                    direction = !direction;
                    sr.flipX = false;
                    canSwitchAnim = 1f;
                    playingSwitch = true;
                    anim.Play("Barrens_Melee_Patrol_Switch");
                }
            }
            else if (direction)
            {
                if (currentPositionX < maxPatrolRight && playingSwitch == false)
                {
                    destination = maxPatrolRight;
                    rb.linearVelocity = new Vector2(walkSpeed, rb.linearVelocityY);
                    anim.Play("Barrens_Melee_Patrol_Walk");
                }

                if (currentPositionX >= maxPatrolRight)
                {
                    direction = !direction;
                    sr.flipX = true;
                    canSwitchAnim = 1;
                    playingSwitch = true;
                    anim.Play("Barrens_Melee_Patrol_Switch");
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
