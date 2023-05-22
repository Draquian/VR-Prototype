using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonLogic : MonoBehaviour
{
    // Start is called before the first frame update
    public int damage = 10;
    public int attackSpeed = 2;
    public float attackSpeedTimer = 2;

    public bool attacking = false;

    private GameObject target;
    private Animator animator;

    private float attackDuration = 0;

    public float life = 20;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, target.transform.position) <= 2)
        {

            if (attackSpeedTimer >= attackSpeed)
            {
                attacking = true;
                Debug.Log("Attacking");
                animator.SetBool("Walk", false);
                animator.SetBool("Run", false);
                animator.SetBool("Atack", attacking);

                //animator.GetCurrentAnimatorStateInfo(0).IsName("Eat");
                /*if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Eat"))
                {
                    attackSpeedTimer = 0;
                }*/
                attackDuration += 1 * Time.deltaTime;
                if (attackDuration >= 1.5f)
                {
                    attackSpeedTimer = 0;
                    attackDuration = 0;
                }


                Debug.Log(animator.GetCurrentAnimatorStateInfo(0).IsName("Eat"));
            }
            else if (attackSpeedTimer < attackSpeed)
            {
                attacking = false;
                attackSpeedTimer += 1 * Time.deltaTime;
                animator.SetBool("Atack", attacking);

            }

        }
        else if (Vector3.Distance(transform.position, target.transform.position) > 2)
        {

            attacking = false;
            animator.SetBool("Atack", attacking);


        }
    }
}
