using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenLogic : MonoBehaviour
{
    public int damage = 10;
    public int attackSpeed = 2;
    public float attackSpeedTimer = 2;

    public bool attacking = false;

    private GameObject target;
    private Animator animator;

    private float attackDuration = 0;

    public float hp = 20;

    public ParticleSystem deadPartycle;
    public bool kill = false;
    private float tempDeadTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        deadPartycle.Pause();
    }

    // Update is called once per frame
    void Update()
    {

        if (kill)
        {
            TakeDamage(50);
        }
        if (Vector3.Distance(transform.position, target.transform.position) <= 2)
        {

            if (attackSpeedTimer >= attackSpeed)
            {
                Attack();
            }
            else if (attackSpeedTimer < attackSpeed)
            {
                attacking = false;
                attackSpeedTimer += 1 * Time.deltaTime;
                animator.SetBool("Eat", attacking);

            }

        }
        else if (Vector3.Distance(transform.position, target.transform.position) > 2)
        {

            attacking = false;
            animator.SetBool("Eat", attacking);

        }
        if (hp <= 0)
        {
            tempDeadTimer += 1 * Time.deltaTime;
            if (tempDeadTimer >= 1)
            {
                Destroy(gameObject);
            }

        }
    }
    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("Detectando");

        if (other.tag == "Player" && attacking)
        {
            //Hace da�o a player
            Debug.Log("Da�oooooooooooooooooooooooo");
        }

        if (other.tag == "InteractiveMapObject")
        {
            kill = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Detectando2");

        if (other.tag == "Player" && attacking)
        {
            //Hace da�o a player
            Debug.Log("Da�oooooooooooooooooooooooo2");
        }
    }


    public void Attack()
    {

        attacking = true;
        Debug.Log("Attacking");
        animator.SetBool("Walk", false);
        animator.SetBool("Run", false);
        animator.SetBool("Eat", attacking);

        attackDuration += 1 * Time.deltaTime;
        if (attackDuration >= 1.5f)
        {
            attackSpeedTimer = 0;
            attackDuration = 0;
        }


        Debug.Log(animator.GetCurrentAnimatorStateInfo(0).IsName("Eat"));
    }
    public void TakeDamage(int damageAmount)
    {
        hp -= damageAmount;
        if (hp <= 0)
        {
            //Die
            Destroy(gameObject.GetComponentInChildren<SkinnedMeshRenderer>());
            deadPartycle.Play();
        }
        else
        {

        }
    }

}
