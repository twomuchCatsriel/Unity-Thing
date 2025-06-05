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

    public float cooldown = -1;
    float defaultGunCooldown = 0.3f;
    float defaultSwordCooldown = 1; 


    bool canAttack = true;

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
            if (AttackAction.IsPressed())
            {
                Attack("Slash", true);
            }
            else if (ShootAction.IsPressed())
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
            cooldown = defaultGunCooldown;
        }
        else if (type == true) // sword
        {
            Debug.Log(msg);
            cooldown = defaultSwordCooldown;

            anim.Play("Niko_Slash");
        }
    }
}
