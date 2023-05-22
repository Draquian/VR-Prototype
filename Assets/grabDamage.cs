using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabDamage : MonoBehaviour
{
    public bool canMakeDamage = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamageEnemy()
    {
        tag = "InteractiveMapObject";
        canMakeDamage = true;
    }
}
