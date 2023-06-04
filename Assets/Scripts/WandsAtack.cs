using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
public class WandsAtack : MonoBehaviour
{
    public Rigidbody _BulletTornado;
    public Rigidbody _BulletWater;
    public Rigidbody _BulletMeteore;
    public Rigidbody _BulletFire;
    public Select_Spell Select_Spell;
    public GameObject _startPos;
    public float _speed;
   
    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Input.anyKey);
        if (Input.GetKeyDown(KeyCode.Space) && Select_Spell._stoneWand == Select_Spell._currrentSpell)
          { 
            Rigidbody createBullet = Instantiate(_BulletMeteore, _startPos.transform.position, transform.rotation) as Rigidbody;

            createBullet.velocity = transform.TransformDirection(new Vector3(0, _speed, 0));
        }
        else if (Input.GetKeyDown(KeyCode.Space) && Select_Spell._waterWand == Select_Spell._currrentSpell)
        {
            Rigidbody createBullet = Instantiate(_BulletWater, _startPos.transform.position, transform.rotation) as Rigidbody;

            createBullet.velocity = transform.TransformDirection(new Vector3(0, _speed, 0));
        }
        else if (Input.GetKeyDown(KeyCode.Space) && Select_Spell._windWand == Select_Spell._currrentSpell)
        {
            Rigidbody createBullet = Instantiate(_BulletTornado, _startPos.transform.position, transform.rotation) as Rigidbody;

            createBullet.velocity = transform.TransformDirection(new Vector3(0, _speed, 0));
        }
        else if (Input.GetKeyDown(KeyCode.Space) && Select_Spell._fireWand == Select_Spell._currrentSpell)
        {
            Rigidbody createBullet = Instantiate(_BulletFire, _startPos.transform.position, transform.rotation) as Rigidbody;

            createBullet.velocity = transform.TransformDirection(new Vector3(0, _speed, 0));
        }
    }
}
