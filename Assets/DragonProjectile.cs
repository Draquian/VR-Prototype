using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonProjectile : MonoBehaviour
{
    PlayerScript playerScript;
    DragonMovement drag;
    public int damage = 10;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     if(Vector3.Distance(gameObject.transform.position, player.transform.position) < 0.5f)
        {
            //playerScript.PlayerDamaged(damage);
            gameObject.SetActive(false);
        }   
    }

}
