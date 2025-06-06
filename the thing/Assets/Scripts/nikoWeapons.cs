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
    float defaultGunCooldown = 0.3f;
    float defaultSwordCooldown = 0.5f;

    public bool canAttack = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AttackAction = InputSystem.actions.FindAction("Attack");
        ShootAction = InputSystem.actions.FindAction("Shoot");
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;

        if (cooldown < 0)
        {
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
        }
    }
}
