using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DemonScript : MonoBehaviour
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    private GameObject target;
    public NavMeshAgent agent;
    private Animator animator;
    private DemonLogic Logic;
  //  private Vector3 minDistance = new Vector3(-0.5f, 0f,0f);
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        Logic = GetComponent<DemonLogic>();

    }

    // Update is called once per frame
    void Update()
    {

        agent.SetDestination(target.transform.position);
        if (Vector3.Distance(transform.position, target.transform.position) <= 0.5 && !Logic.attacking)
        {
            // GetComponent<Animator>().Play("Idle");
            animator.SetBool("Walk", false);
            animator.SetBool("Run", false);

            //animator.SetBool("Idle", true);

            Debug.Log("Idle");

        }
        else if (Vector3.Distance(transform.position, target.transform.position) <= 2 && !Logic.attacking)
        {
            //GetComponent<Animator>().Play("Walk In Place");
            //animator.Play("Walk In Place");
            animator.SetBool("Run", false);
            animator.SetBool("Walk", true);
            Debug.Log("Walk");
        }
        else if (Vector3.Distance(transform.position, target.transform.position) >= 2 && !Logic.attacking)
        {
            //GetComponent<Animator>().Play("Run In Place");
            //animator.Play("Run In Place");
            animator.SetBool("Walk", false);
            animator.SetBool("Run", true);

            Debug.Log("Run");

        }


    }
}
