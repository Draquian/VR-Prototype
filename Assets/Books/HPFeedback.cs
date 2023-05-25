using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPFeedback : MonoBehaviour
{
    public Light myLight;

    //public ParticleSystem ps;
    ParticleSystem main;
    PlayerScript _playerHP;
    //public float _playerHP;

    public GameObject player;
    public GameObject partilce;

    // Start is called before the first frame update
    void Start()
    {
        _playerHP = player.GetComponent<PlayerScript>();
        main = partilce.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        main.startLifetime = _playerHP._playerHp / 500;
        myLight.intensity = _playerHP._playerHp;
    }
}
