using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPFeedback : MonoBehaviour
{
    public Light myLight;

    public ParticleSystem ps;
    ParticleSystem.MainModule main;
    public float _playerHP = 100;
    // Start is called before the first frame update
    void Start()
    {
        main = ps.main;
    }

    // Update is called once per frame
    void Update()
    {
        main.startLifetime = _playerHP / 500;
        myLight.intensity = _playerHP;
    }
}
