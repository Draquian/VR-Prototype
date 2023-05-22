using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int _playerHp;
    float _timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        _timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerDamaged(int damage)
    {
        if (_timer <= 0)
        {
            _playerHp -= damage;
            _timer = 3;
            //Debug.Log(_timer);
        }
        else if (_timer > 0)
        {
            _timer -= 1f * Time.deltaTime;
        }
    }
}
