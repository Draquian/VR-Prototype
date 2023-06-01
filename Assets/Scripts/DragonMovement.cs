using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DragonMovement : MonoBehaviour
{
    public AudioClip Fly;
    public AudioClip Attack;
    public AudioClip Hit;
    public AudioClip Death;
    public GameObject player;
    public GameObject dragonProjectile;
    public GameObject dragonMouth;
    public NavMeshAgent agent;
    AudioSource audiosource;
    public bool hasCreatedProjectile = false;
    Vector3 dist;
    public float dragonDistance;
    float dragonHp = 150.0f;
    private Animator animator;
    private float speed = 3.0f;
    private float projectileSpeed = 0.3f;
    public bool isFloating = false;
    float deathTimer = 0.0f;
    float hitTimer = 0.0f;
    private float attackCooldown = 0.0f;
    bool hit = false;
    // Start is called before the first frame update
    void Start()
    {
        dragonProjectile.SetActive(false);
        animator = GetComponent<Animator>();
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(agent.stoppingDistance);
        //Debug.Log(dragonDistance);
        agent.SetDestination(player.transform.position);
        agent.speed = speed;
        dragonDistance = Vector3.Distance(player.transform.position, gameObject.transform.position);
        if(dragonDistance < agent.stoppingDistance + 2)
        {
            attackCooldown +=Time.deltaTime;
           // Debug.Log("Dragon is not moving");

            if(attackCooldown > 4.25f)
            {
                animator.SetBool("Attack", true);
                hasCreatedProjectile = false;


            }

            if (hasCreatedProjectile == false && attackCooldown > 5.0f)
            {
                audiosource.PlayOneShot(Attack);
                attackCooldown = 0.0f;
                animator.SetBool("Attack", false);
                hasCreatedProjectile = true;
                //Debug.Log("Create Projectile");
                dragonProjectile.SetActive(true);
                dragonProjectile.transform.position = dragonMouth.transform.position;

                dragonProjectile.transform.position = dragonMouth.transform.position;
                dist = player.transform.position - dragonMouth.transform.position;


            }
        }
        if (dragonDistance < agent.stoppingDistance + 4)
        {

            isFloating = true;
            animator.SetBool("isFloating", true);
        }

        if (hasCreatedProjectile == true)
        {

            Seek(dragonProjectile, player, projectileSpeed);
            
        }

        if(dragonHp <= 0)
        {

            deathTimer += Time.deltaTime;
            if(deathTimer > 1.25f)
            {
                Destroy(gameObject);
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "playerProjectileTornado")
        {
            //TakeDamage(5);
            //other.gameObject.SetActive(false);
        }
    }

    private void TakeDamage(float damage)
    {
        dragonHp -= damage;

        if (dragonHp > 0)
        {
            Debug.Log("Dragon Hit!!!");
            audiosource.PlayOneShot(Hit);
            
        }
        else
        {
            animator.SetBool("Dead", true);
            audiosource.PlayOneShot(Death);

        }
    }
    void Seek(GameObject seeker, GameObject target, float speed)
    {
        seeker.transform.Translate(dist * speed * Time.deltaTime);
    }
}
