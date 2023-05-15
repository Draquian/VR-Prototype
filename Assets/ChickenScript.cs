using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChickenScript : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject target;
    public NavMeshAgent agent;
    private Animator animator;
    
    
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
     
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.transform.position);
        if (agent.speed == 0)
        {
           // GetComponent<Animator>().Play("Idle");
            animator.SetBool("Idle", true);

            Debug.Log("Idle");

        }
        else if (agent.speed <= 2)
        {
            //GetComponent<Animator>().Play("Walk In Place");
            //animator.Play("Walk In Place");
            animator.SetBool("Walk", true);
            Debug.Log("Walk");
        }
        else if (agent.speed > 2)
        {
            //GetComponent<Animator>().Play("Run In Place");
            //animator.Play("Run In Place");
            animator.SetBool("Run", true);

            Debug.Log("Run");

        }
    }
}
