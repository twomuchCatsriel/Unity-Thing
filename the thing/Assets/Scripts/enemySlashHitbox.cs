using Unity.VisualScripting;
using UnityEngine;

public class enemySlashHitbox : MonoBehaviour
{
    public bool playerIsInRange = false;
    public float defaultCooldown;
    public bool isPlayingSlash = false;

    float currentCooldown = 1f;
    float hitboxDuration = 0.75f;

    BoxCollider2D hitbox;

    GameObject meleeEnemy;
    enemyDetectionRange enemyDetectionScript;
    GameObject hitboxObject;
    meleeAnimationManager animScript;

    Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hitbox = gameObject.transform.parent.GetChild(2).GetComponent<BoxCollider2D>();
        enemyDetectionScript = gameObject.transform.parent.GetChild(1).GetComponent<enemyDetectionRange>();
        hitboxObject = gameObject.transform.parent.GetChild(2).gameObject;
        meleeEnemy = gameObject.transform.parent.gameObject;
        animScript = gameObject.transform.GetComponentInParent<meleeAnimationManager>();

        anim = meleeEnemy.GetComponent<Animator>();

        playerIsInRange = false;

        Debug.Log(hitbox);
    }
    
    void Update()
    {
        currentCooldown -= Time.deltaTime;
        hitboxDuration -= Time.deltaTime;

        if (currentCooldown < 0)
        {
            Attack();
        }

        if (hitboxDuration < 0 || playerIsInRange == false)
        {
            animScript.animationState = 0;
            hitboxObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsInRange = false;
        }

        hitboxObject.SetActive(false);
    }

    void Attack()
    {
        animScript.animationState = 1;
        currentCooldown = 1.5f;
        hitboxDuration = 0.75f;

        hitboxObject.SetActive(true);
        isPlayingSlash = true;
        anim.Play("Barrens_Melee_Attack");

        if (enemyDetectionScript.playerIsRight == false)
        {
            hitbox.offset = new Vector2(2f, 0);
        }
        else if (enemyDetectionScript.playerIsRight)
        {
            hitbox.offset = new Vector2(-2f, 0);
        }
    }
}
