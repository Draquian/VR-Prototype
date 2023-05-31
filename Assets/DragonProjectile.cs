using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonProjectile : MonoBehaviour
{
    PlayerScript playerScript;
    DragonMovement drag;
    public int damage = 10;
    public GameObject player;
    public AudioClip Collision;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerScript.PlayerDamaged(damage);
            gameObject.SetActive(false);
        }
        else if (other.tag == "playerProjectile")
        {
            gameObject.SetActive(false);
        }
    }
}
