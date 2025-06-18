using UnityEngine;

public class meleeAnimationManager : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;

    public int animationState = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animationState == 0)
        {
            anim.Play("Barrens_Melee_Patrol_Walk");
        }
        else if (animationState == 1)
        {
            anim.Play("Barrens_Melee_Attack");
        }
    }
}
