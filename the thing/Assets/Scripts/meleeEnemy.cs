using Unity.VisualScripting;
using UnityEngine;
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

    GameObject enemyAttackRange;
    GameObject enemyDetectionRange;
    GameObject hitbox;

    float maxPatrolLeft;
    float maxPatrolRight;

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
    }

    // Update is called once per frame
    void Update()
    {
        float currentPositionX = gameObject.transform.position.x;

        if (playerDetected == false)
        {
            if (currentPositionX > maxPatrolLeft)
            {
                rb.linearVelocity = new Vector2(walkSpeed, 0) * 5;
            }
        }
    }
}
