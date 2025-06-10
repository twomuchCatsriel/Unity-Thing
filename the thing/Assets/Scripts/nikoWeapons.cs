using NUnit.Framework.Interfaces;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class nikoWeapons : MonoBehaviour
{
    InputAction AttackAction;
    InputAction ShootAction;
    SpriteRenderer sr;
    Animator anim;

    float cooldown = -1;
    float defaultGunCooldown = 0.25f;
    float defaultSwordCooldown = 0.4f;

    movement movementScript;
    float offsetAmount = 1.4f;

    GameObject hitbox;
    BoxCollider2D hitboxCollider;

    public bool canAttack = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AttackAction = InputSystem.actions.FindAction("Attack");
        ShootAction = InputSystem.actions.FindAction("Shoot");
        hitbox = gameObject.transform.GetChild(0).gameObject;

        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        movementScript = GetComponent<movement>();
        hitboxCollider = hitbox.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;

        if (cooldown < 0)
        {
            hitbox.SetActive(false);
            canAttack = true;
            if (AttackAction.triggered)
            {
                Attack("Slash", true);
            }
            else if (ShootAction.triggered)
            {
                Attack("Pew", false);
            }
        }
    }

    void Attack(string msg, bool type)
    {
        if (type == false) // Gun
        {
            Debug.Log(msg);
            canAttack = false;
            cooldown = defaultGunCooldown;
        }
        else if (type == true) // sword
        {
            Debug.Log(msg);
            canAttack = false;
            cooldown = defaultSwordCooldown;

            anim.Play("Niko_Slash");

            // Hitbox
            if (movementScript.isMovingRight)
            {
                hitboxCollider.offset = new Vector2(offsetAmount, 0);
            }
            else
            {
                hitboxCollider.offset = new Vector2(-offsetAmount, 0);
            }
            hitbox.SetActive(true);
        }
    }
}