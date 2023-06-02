using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WandsAtack : MonoBehaviour
{
    public Rigidbody _BulletTornado;
    public Rigidbody _BulletWater;
    public Rigidbody _BulletMeteore;
    public Rigidbody _BulletFire;
    Select_Spell Select_Spell;
    public GameObject _startPos;
    public float _speed;
   
    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Rigidbody createBullet = Instantiate(_BulletMeteore, _startPos.transform.position, transform.rotation) as Rigidbody;
            Rigidbody createBullet = Instantiate(_BulletMeteore, _startPos.transform.position, transform.rotation) as Rigidbody;

            createBullet.velocity = transform.TransformDirection(new Vector3(0, _speed, 0));
            //Physics.IgnoreCollision(createBullet.GetComponent<Collider>(), GetComponent<Collider>());

            
        }
    }
}
