using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenLogic : MonoBehaviour
{
    public int damage = 10;
    public int attackSpeed = 2;
    public bool attacking = false;

    private GameObject target;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, target.transform.position) < 2)
        {
            attacking = true;
            Debug.Log("Attacking");
            animator.SetBool("Walk", false);
            animator.SetBool("Run", false);
            animator.SetBool("Eat", attacking);
        }
    }
}
