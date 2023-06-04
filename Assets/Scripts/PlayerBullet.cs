using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    float timer = 0.0f;
    public GameObject _player;
    public float KnockbackForce;
    public GameObject _bomb;
    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        _bomb.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(gameObject.transform.position,_player.transform.position) > 50f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider collison)
    {
        if(gameObject.tag == "playerProjectileTornado" && collison.tag == "Enemy")
        {
           collison.transform.position += _player.transform.forward * Time.deltaTime * KnockbackForce;
        }
        if (gameObject.tag == "playerProjectileFire" && (collison.tag == "Box" || collison.tag == "Enemy"))
        {
            Debug.Log("BOMBA");
            _bomb.SetActive(true);
        }
        if (gameObject.tag == "playerProjectileRock" && (collison.tag == "Box" || collison.tag == "Enemy"))
        {
            collison.transform.position += _player.transform.forward * Time.deltaTime * KnockbackForce;
            Debug.Log("Crash");
        }
    }
}
