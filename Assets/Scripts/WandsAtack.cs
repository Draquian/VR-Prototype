using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WandsAtack : MonoBehaviour
{
    public Rigidbody _Bullet;
    public GameObject _startPos;
    public float _speed;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Rigidbody createBullet = Instantiate(_Bullet, _startPos.transform.position, transform.rotation) as Rigidbody;

            createBullet.velocity = transform.TransformDirection(new Vector3(0, _speed, 0));
            //Physics.IgnoreCollision(createBullet.GetComponent<Collider>(), GetComponent<Collider>());
        }
    }
}
