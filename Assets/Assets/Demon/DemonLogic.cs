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

    public ParticleSystem deadPartycle;
    public ParticleSystem deadPartycle2;
    public bool kill = false;
    private float tempDeadTimer = 0;
    [SerializeField] int deadParticleDuration = 2;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        deadPartycle.Pause();
        deadPartycle2.Pause();
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
                animator.SetBool("Attack", attacking);

                attackDuration += 2*Time.deltaTime;

                if (attackDuration >= 2f)
                {
                    attackSpeedTimer = 0;
                    attackDuration = 0;
                }

            
            }
            else if (attackSpeedTimer < attackSpeed)
            {
                attacking = false;
                attackSpeedTimer += 1 * Time.deltaTime;
                animator.SetBool("Attack", attacking);
            }

        }
        else if (Vector3.Distance(transform.position, target.transform.position) > 2)
        {

            attacking = false;
            animator.SetBool("Attack", attacking);
        }

        if (life<=0)
        {
            tempDeadTimer += 1 * Time.deltaTime;
                if (tempDeadTimer >= deadParticleDuration)
            {
                Destroy(gameObject);
            }
        }

     
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "playerProjectile")
        {
            TakeDamage(50);
        }


        if (other.tag == "Player" && attacking)
        {
            //Hace daño a player
            //playerref.playerdamaged(damage);
            other.gameObject.GetComponent<PlayerScript>().PlayerDamaged(damage);

        }

        if (other.tag == "InteractiveMapObject")
        {
            kill = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("L'estic Tocant");
        if (other.tag == "Player" && attacking == true)
        {
            other.gameObject.GetComponent<PlayerScript>().PlayerDamaged(damage);
            Debug.Log("Estic fent danyo");
        }
    }

    public void TakeDmg(int Income_dmg)
    {
        life = life - Income_dmg;

        if (life <= 0)
        {
            animator.SetTrigger("Dead");

            Destroy(gameObject.GetComponentInChildren<SkinnedMeshRenderer>());
        }
    }

    public void TakeDamage (int damageAmount)
    {
        life -= damageAmount;
        if (life <= 0)
        {
            Destroy(gameObject.GetComponentInChildren<SkinnedMeshRenderer>());
                deadPartycle.Play();
                deadPartycle2.Play();
            
        }
    }
}

