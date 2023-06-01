using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public int _playerHp;
    float _timer = 0;
    public float inmunityTime = 2;
    public int score;
    public GameOver gameOver;

   // Text _text;
    // Start is called before the first frame update
    void Start()
    {
      //  _text = GameObject.FindGameObjectWithTag("VidaUI").GetComponent<Text>();
        _timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
       // _text.text = _playerHp.ToString();
       if(_playerHp <= 0)
        {
            gameOver.Setup(score);
        }
    }

    public void PlayerDamaged(int damage)
    {
        if (_timer <= 0)
        {
            _playerHp -= damage;
            _timer = inmunityTime;
            //Debug.Log(_timer);
        }
        else if (_timer > 0)
        {
            _timer -= 1f * Time.deltaTime;
        }
    }
}
